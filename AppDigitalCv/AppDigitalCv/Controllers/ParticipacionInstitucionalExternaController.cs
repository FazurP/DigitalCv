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
    public class ParticipacionInstitucionalExternaController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperiorBusiness;
        IPeriodoBusiness periodoBusiness;
        IDocumentosBusiness documentosBusiness;
        IParticipacionInstitucionalExternaBusiness participacionInstitucionalExtenaBusiness;
        public ParticipacionInstitucionalExternaController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness
            , IPeriodoBusiness _periodoBusiness, IDocumentosBusiness _documentosBusiness, IParticipacionInstitucionalExternaBusiness
            _participacionInstitucionalExternaBusiness)
        {
            institucionSuperiorBusiness = _institucionSuperiorBusiness;
            periodoBusiness = _periodoBusiness;
            documentosBusiness = _documentosBusiness;
            participacionInstitucionalExtenaBusiness = _participacionInstitucionalExternaBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idCatInstitucionSuperior = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "idInstitucionSuperior", "strDescripcion");
                ViewBag.idCatPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
            
        }
        [HttpPost]
        public ActionResult Create(ParticipacionInstitucionalExternaVM participacionInstitucionalExternaVM)
        {
            if (ModelState.IsValid)
            {
                object[] obj = CrearDocumentoPersonales(participacionInstitucionalExternaVM);

                if (obj[0].Equals(true))
                {
                    participacionInstitucionalExternaVM.documentos = new DocumentosVM { StrUrl = obj[1].ToString() };
                    AddUpdatePartipacionInstitucionalExterna(participacionInstitucionalExternaVM);
                }
            }
            return RedirectToAction("Create", "ParticipacionInstitucionalExterna");

        }

        private Object[] CrearDocumentoPersonales(ParticipacionInstitucionalExternaVM participacionInstitucionalExternaVM)
        {
            Object[] respuesta = new Object[2];
            participacionInstitucionalExternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (participacionInstitucionalExternaVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, participacionInstitucionalExternaVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(participacionInstitucionalExternaVM);
            }
            return respuesta;
        }


        /// <summary>
        /// Este metodo se encarga de insertar los datos en la base de datos
        /// </summary>
        /// <param name="participacionInstitucionalExternaVM"></param>
        /// <returns>true o false</returns>
        private bool AddUpdatePartipacionInstitucionalExterna(ParticipacionInstitucionalExternaVM participacionInstitucionalExternaVM)
        {
            bool respuesta = false;

            ParticipacionInstitucionalExternaDomainModel participacionInstitucionalExternaDM = new ParticipacionInstitucionalExternaDomainModel();

            AutoMapper.Mapper.Map(participacionInstitucionalExternaVM, participacionInstitucionalExternaDM);
            respuesta = participacionInstitucionalExtenaBusiness.AddUpdateParticipacion(participacionInstitucionalExternaDM);
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
            List<ParticipacionInstitucionalExternaDomainModel> participacionDM = new List<ParticipacionInstitucionalExternaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                participacionDM = participacionInstitucionalExtenaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Where(p => p.strActividad.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = participacionInstitucionalExtenaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Count();


                participacionDM = participacionInstitucionalExtenaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).OrderBy(p => p.strActividad)
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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Eliminar
        /// </summary>
        /// <param name="idCatDocumento"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetParticipacionById(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalExternaDomainModel participacionDM =
                participacionInstitucionalExtenaBusiness.GetParticipacion(idPersonal, idCatDocumento);

            if (participacionDM != null)
            {
                ParticipacionInstitucionalExternaVM participacionVM = new ParticipacionInstitucionalExternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Eliminar", participacionVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un objeto de la base de datos
        /// </summary>
        /// <param name="participacionVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteParticipacion(ParticipacionInstitucionalExternaVM participacionVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalExternaDomainModel participacionDM =
                participacionInstitucionalExtenaBusiness.GetParticipacion(idPersonal, participacionVM.idCatDocumento);

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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Editar
        /// </summary>
        /// <param name="idCatDocumento"></param>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult GetParticipacionByIdEdit(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalExternaDomainModel participacionDM =
              participacionInstitucionalExtenaBusiness.GetParticipacion(idPersonal, idCatDocumento);
            if (participacionDM!= null)
            {
                ViewBag.idCatInstitucionSuperior = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "idInstitucionSuperior", "strDescripcion");
                ParticipacionInstitucionalExternaVM participacionVM = new ParticipacionInstitucionalExternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Editar", participacionVM);
            }
            return View();

        }
        /// <summary>
        /// Este metodo se encarga de actualizar un objeto de la base de datos.
        /// </summary>
        /// <param name="participacionInstitucionalExternaVM"></param>
        [HttpPost]
        public void EditarParticipacionPersonal(ParticipacionInstitucionalExternaVM participacionInstitucionalExternaVM)
        {

            ParticipacionInstitucionalExternaDomainModel participacionDM = new ParticipacionInstitucionalExternaDomainModel();
            AutoMapper.Mapper.Map(participacionInstitucionalExternaVM, participacionDM);

            if (participacionInstitucionalExternaVM.id > 0)
            {
                participacionInstitucionalExtenaBusiness.AddUpdateParticipacion(participacionDM);

            }

        }

    }
}