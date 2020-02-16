using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;


namespace AppDigitalCv.Controllers
{
    public class PremiosDocenteController : Controller
    {
        IPremiosDocenteBusiness IpremiosDocenteBusiness;
        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;

        public PremiosDocenteController(IPremiosDocenteBusiness _IpremiosDocenteBusiness, IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness)
        {
            IpremiosDocenteBusiness = _IpremiosDocenteBusiness;
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }


        [HttpPost]
        public ActionResult Create(PremiosDocenteVM premiosDocenteVM)
        {
            premiosDocenteVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
            if (ModelState.IsValid)
            {
                object[] obj = CrearDocumentoPersonales(premiosDocenteVM);

                if (obj[0].Equals(true))
                {
                    premiosDocenteVM.Documentos = new DocumentosVM { StrUrl = obj[1].ToString() };
                    AddEditPremiosDocente(premiosDocenteVM);
                }
            }

            return RedirectToAction("Create", "PremiosDocente");
        }

        #region  Crear el documento
        private Object[] CrearDocumentoPersonales(PremiosDocenteVM premiosDocenteVM)
        {
            Object[] respuesta = new Object[2];
            premiosDocenteVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (premiosDocenteVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, premiosDocenteVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(premiosDocenteVM);
            }

            return respuesta;
        }

        #endregion

        #region  Agregar Premios del Docente
        private bool AddEditPremiosDocente(PremiosDocenteVM premiosDocenteVM)
        {
            bool resultado = false;
            PremiosDocenteDomainModel premiosDocenteDM = new PremiosDocenteDomainModel();
            AutoMapper.Mapper.Map(premiosDocenteVM, premiosDocenteDM);///hacemos el mapeado de la entidad

             resultado = IpremiosDocenteBusiness.AddUpdatePremiosDocente(premiosDocenteDM);
            return resultado;
        }

        public ActionResult UpdatePremiosDocente(PremiosDocenteVM premiosDocenteVM)
        {
            if (premiosDocenteVM.id > 0)
            {
                PremiosDocenteDomainModel premiosDocenteDomainModel = new PremiosDocenteDomainModel();

                AutoMapper.Mapper.Map(premiosDocenteVM,premiosDocenteDomainModel);

                IpremiosDocenteBusiness.AddUpdatePremiosDocente(premiosDocenteDomainModel);
            }

            return RedirectToAction("Create","PremiosDocente");
        }
        #endregion

        #region Consultar Datos del Personal Docente
        /// <summary>
        /// Consulta el personal  atraves del identificador 
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>
        /// regresa una entidad del tipo personal domain model
        /// </returns>
        public PersonalDomainModel GetPersonalVM(int idPersonal)
        {
            PersonalDomainModel personalDM = IpersonalBusiness.GetPersonalById(idPersonal);
            return personalDM;
        }

        /// <summary>
        /// Este emetodo se encarga de consultar todos los premios del docente por identificador
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>un objeto del tipo json de la consulta del personal</returns>
        [HttpGet]
        public JsonResult GetPremiosDocente()
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            var  premios= IpremiosDocenteBusiness.GetPremiosDocenteById(idPersonal);
            return Json(premios, JsonRequestBehavior.AllowGet);
        }


        #endregion


        [HttpGet]
        public JsonResult GetDatosFamiliaresTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<PremiosDocenteDomainModel> premios = new List<PremiosDocenteDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                premios = IpremiosDocenteBusiness.GetPremiosDocenteById(IdentityPersonal).Where(p => p.StrNombrePremio.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = IpremiosDocenteBusiness.GetPremiosDocenteById(IdentityPersonal).Count();

                premios = IpremiosDocenteBusiness.GetPremiosDocenteById(IdentityPersonal).OrderBy(p=> p.IdPersonal)
                          .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
                    
            }
            return Json(new
            {
                aaData = premios,
                sEcho = param.sEcho,
                iTotalDisplayRecords = premios.Count(),
                iTotalRecords = premios.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetPremioUpdateByPersonal(int _idPremio)
        {
            PremiosDocenteVM premiosDocenteVM = new PremiosDocenteVM();
            if (_idPremio > 0)
            {
                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                PremiosDocenteDomainModel premiosDocenteDomainModel = new PremiosDocenteDomainModel();

                premiosDocenteDomainModel = IpremiosDocenteBusiness.GetPremioDocenteById(_idPremio, idPersonal);

                if (premiosDocenteDomainModel != null)
                {
                    AutoMapper.Mapper.Map(premiosDocenteDomainModel,premiosDocenteVM);
                }
            }

            return PartialView("_Editar", premiosDocenteVM);
        }


        #region Consultar para Eliminar de Forma permanente el registro
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idEnfermedad">recibe un identificador de premios del docente</param>
        /// <returns>regresa un premio del docente en una vista</returns>
        public ActionResult GetPremioDeleteByPersonal(int _idPremio)
        {
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            PremiosDocenteDomainModel premioDDM=  IpremiosDocenteBusiness.GetPremioDocenteById(_idPremio, IdPersonal);
            if (premioDDM != null)
            {
                PremiosDocenteVM premiosDocenteVM = new PremiosDocenteVM();
                
                AutoMapper.Mapper.Map(premioDDM, premiosDocenteVM);
                return PartialView("_Eliminar", premiosDocenteVM);
            }
            return View();
        }

        #endregion

        #region Eliminar Premios Docente
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idEnfermedad">recibe un identificador del documento</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public ActionResult EliminarPremiosDocente(int id)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombreUsuario = SessionPersister.AccountSession.NombreCompleto;
            PremiosDocenteDomainModel premioDDM = IpremiosDocenteBusiness.GetPremioDocenteById(id, idPersonal);
            
            if (premioDDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + premioDDM.Documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    IdocumentosBusiness.DeleteDocumento(premioDDM.IdDocumento);
                }
                                
            }
            return RedirectToAction("Create","PremiosDocente");
        }
        #endregion

        [HttpGet]
        public ActionResult DisplayPremiosDocente(int _idPremio)
        {
            if (_idPremio > 0)
            {
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                PremiosDocenteDomainModel premiosDocenteDomainModel = IpremiosDocenteBusiness.GetPremioDocenteById(_idPremio, idPersonal);
                PremiosDocenteVM premiosDocenteVM = new PremiosDocenteVM();
                AutoMapper.Mapper.Map(premiosDocenteDomainModel, premiosDocenteVM);
                return PartialView("_verDatos", premiosDocenteVM);
            }
            return PartialView();        
        }


    }
}