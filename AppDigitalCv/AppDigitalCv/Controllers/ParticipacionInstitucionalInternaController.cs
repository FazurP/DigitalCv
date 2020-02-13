using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ParticipacionInstitucionalInternaController : Controller
    {
        IPeriodoBusiness periodoBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        ITipoActividad tipoActividad;
        IDocumentosBusiness documentosBusiness;
        IParticipacionInstitucionalInternaBusiness participacionInstitucionalInternaBusiness;
        public ParticipacionInstitucionalInternaController(IProgramaEducativoBusiness _programaEducativoBusiness,
            IPeriodoBusiness _periodoBusiness, ITipoActividad _tipoActividad, IDocumentosBusiness _documentosBusiness
            , IParticipacionInstitucionalInternaBusiness _participacionInstitucionalInternaBusiness)
        {
            programaEducativoBusiness = _programaEducativoBusiness;
            tipoActividad = _tipoActividad;
            periodoBusiness = _periodoBusiness;
            documentosBusiness = _documentosBusiness;
            participacionInstitucionalInternaBusiness = _participacionInstitucionalInternaBusiness;
        }
        /// <summary>
        /// Este metodo se encarga de cargar la pagina principal
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idCatProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.idCatTipoActividad = new SelectList(tipoActividad.GetTiposActividades(), "id", "strDescripcion");
                ViewBag.idCatPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");
                return View();
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }
           
        }
        /// <summary>
        /// Este metodo se encarga de obtener los datos y validar los mismos
        /// </summary>
        /// <param name="institucionalInternaVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult Create (ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {
            if (ModelState.IsValid)
            {
                object[] obj = CrearDocumentoPersonales(institucionalInternaVM);

                if (obj[0].Equals(true))
                {
                    institucionalInternaVM.documentos = new DocumentosVM { StrUrl = obj[1].ToString() };
                    AddUpdatePartipacionInstitucionalInterna(institucionalInternaVM);
                }

            }
            return RedirectToAction("Create","ParticipacionInstitucionalInterna");
        }

        private Object[] CrearDocumentoPersonales(ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {
            Object[] respuesta = new Object[2];
            institucionalInternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (institucionalInternaVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, institucionalInternaVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(institucionalInternaVM);
            }
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de insertar el objeto en la base de datos
        /// </summary>
        /// <param name="institucionalInternaVM"></param>
        /// <returns></returns>
        private bool AddUpdatePartipacionInstitucionalInterna(ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {
            bool respuesta = false;

            ParticipacionInstitucionalInternaDomainModel participacionInstitucionalInternaDM = new ParticipacionInstitucionalInternaDomainModel();

            AutoMapper.Mapper.Map(institucionalInternaVM, participacionInstitucionalInternaDM);

            respuesta = participacionInstitucionalInternaBusiness.AddUpdateParticipacion(participacionInstitucionalInternaDM);
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de cargar y mostrar los objetos de la persona en la tabla
        /// </summary>
        /// <param name="param"></param>
        /// <returns>un Json con los objetos</returns>
        [HttpGet]
        public JsonResult GetParticipaciones(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ParticipacionInstitucionalInternaDomainModel> participacionDM = new List<ParticipacionInstitucionalInternaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                participacionDM = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Where(p => p.strActividad.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Count();


                participacionDM = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).OrderBy(p => p.strActividad)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = participacionDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = participacionDM.Count(),
                iTotalRecords = participacionDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        #region Metodos para la eliminacion
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Eliminar
        /// </summary>
        /// <param name="idCatDocumento"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetParticipacionById(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
                participacionInstitucionalInternaBusiness.GetParticipacion(idPersonal, idCatDocumento);

            if (participacionDM != null)
            {
                ParticipacionInstitucionalInternaVM participacionVM = new ParticipacionInstitucionalInternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Eliminar", participacionVM);
            }

            return View();
        }        
        /// <summary>
        /// Este metodo se encarga de Eliminar un objeto de la base de datos
        /// </summary>
        /// <param name="participacionVM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteParticipacion(ParticipacionInstitucionalInternaVM participacionVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
                participacionInstitucionalInternaBusiness.GetParticipacion(idPersonal, participacionVM.idCatDocumento);

            if (participacionDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + participacionDM.documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(participacionVM.idCatDocumento);
                }            
            }

            return View(Create());
        }
        #endregion
        #region Metodos para la Actualizacion
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Editar
        /// </summary>
        /// <param name="idCatDocumento"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetParticipacionByIdEdit(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
              participacionInstitucionalInternaBusiness.GetParticipacion(idPersonal, idCatDocumento);
            if (participacionDM != null)
            {

                ViewBag.idCatProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.idCatTipoActividad = new SelectList(tipoActividad.GetTiposActividades(), "id", "strDescripcion");
                ViewBag.idCatPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");
            
                ParticipacionInstitucionalInternaVM participacionVM = new ParticipacionInstitucionalInternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Editar", participacionVM);
            }
            return View();

        }
        /// <summary>
        /// Este metodo se encarga de actualizar un objeto de la base de datos
        /// </summary>
        /// <param name="participacionInstitucionalInternaVM"></param>
        [HttpPost]
        public void EditarParticipacionPersonal(ParticipacionInstitucionalInternaVM participacionInstitucionalInternaVM)
        {

            ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();
            AutoMapper.Mapper.Map(participacionInstitucionalInternaVM, participacionDM);

            if (participacionInstitucionalInternaVM.id > 0)
            {
                participacionInstitucionalInternaBusiness.AddUpdateParticipacion(participacionDM);

            }

        }
        #endregion
    }
}