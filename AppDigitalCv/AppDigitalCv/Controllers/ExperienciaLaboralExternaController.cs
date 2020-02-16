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
    public class ExperienciaLaboralExternaController : Controller
    {
        IPeriodoBusiness periodoBusiness;
        IDocumentosBusiness documentosBusiness;
        IExperienciaLaboralExterna experienciaLaboralExterna;

        public ExperienciaLaboralExternaController(IPeriodoBusiness _periodoBusiness,IDocumentosBusiness _documentosBusiness
            , IExperienciaLaboralExterna _experienciaLaboralExterna)
        {
            periodoBusiness = _periodoBusiness;
            documentosBusiness = _documentosBusiness;
            experienciaLaboralExterna = _experienciaLaboralExterna;
        }
        /// <summary>
        /// Este metodo se encarga de cargar la vista
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create() {

            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");

                return View();
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }
          
        }
        /// <summary>
        /// Este metodo se encarga de registrar los datos ingresados
        /// </summary>
        /// <param name="experienciaLaboralExternaVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult Create(ExperienciaLaboralExternaVM experienciaLaboralExternaVM )
        {
            string nombre = SessionPersister.AccountSession.NombreCompleto;
            experienciaLaboralExternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

            if (ModelState.IsValid)
            {
                object[] obj = CrearDocumentoPersonales(experienciaLaboralExternaVM);

                if (obj[0].Equals(true))
                {
                    experienciaLaboralExternaVM.Documentos = new DocumentosVM { StrUrl = obj[1].ToString() };
                    ExperienciaLaboralExternaDomainModel experienciaLaboralExternaDomainModel = new ExperienciaLaboralExternaDomainModel();
                    AutoMapper.Mapper.Map(experienciaLaboralExternaVM, experienciaLaboralExternaDomainModel);
                    experienciaLaboralExterna.AddUpdateExperiencia(experienciaLaboralExternaDomainModel);
                }
            }
            return RedirectToAction("Create", "ExperienciaLaboralExterna");
        }
        
        private Object[] CrearDocumentoPersonales(ExperienciaLaboralExternaVM experienciaLaboralExternaVM)
        {
            Object[] respuesta = new Object[2];
            experienciaLaboralExternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (experienciaLaboralExternaVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, experienciaLaboralExternaVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(experienciaLaboralExternaVM);
            }

            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de obtener y mostrar los objetos correspondiantes a la persona en una tabla
        /// </summary>
        /// <param name="param"></param>
        /// <returns>un Json con los objetos</returns>
        [HttpGet]
        public JsonResult GetExperiencias(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ExperienciaLaboralExternaDomainModel> experienciaDM = new List<ExperienciaLaboralExternaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                experienciaDM = experienciaLaboralExterna.GetExperienciaLaboralByPersonal(IdentityPersonal).Where(p => p.strInstitucionEmpresa.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = experienciaLaboralExterna.GetExperienciaLaboralByPersonal(IdentityPersonal).Count();


                experienciaDM = experienciaLaboralExterna.GetExperienciaLaboralByPersonal(IdentityPersonal).OrderBy(p => p.strInstitucionEmpresa)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = experienciaDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = experienciaDM.Count(),
                iTotalRecords = experienciaDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Ese metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Eliminar
        /// </summary>
        /// <param name="idDocumento"></param>
        /// <returns>una vista parcial</returns>
        [HttpGet]
        public ActionResult GetExperencia(int idDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ExperienciaLaboralExternaVM experienciaLaboralVM = new ExperienciaLaboralExternaVM();
            ExperienciaLaboralExternaDomainModel experienciaLaboral = experienciaLaboralExterna.GetExperienciaLaboral(idDocumento, idPersonal);

            if (experienciaLaboral != null)
            {
                AutoMapper.Mapper.Map(experienciaLaboral, experienciaLaboralVM);
                return PartialView("_Eliminar", experienciaLaboralVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de borrar un objeto de la base de datos.
        /// </summary>
        /// <param name="experienciaVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteExperiencia(ExperienciaLaboralExternaVM experienciaVM)
        {
            ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();

            experienciaLaboralDM = experienciaLaboralExterna.GetExperienciaLaboral(experienciaVM.idDocumento, experienciaVM.idPersonal);

            if (experienciaLaboralDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + experienciaLaboralDM.Documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(experienciaVM.idDocumento);
                }
            }
            
            return RedirectToAction("Create","ExperienciaLaboralExterna");
        }
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Editar
        /// </summary>
        /// <param name="idDocumento"></param>
        /// <returns>una vista parcial</returns>
        [HttpGet]
        public ActionResult GetExperenciaEdit(int idDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ExperienciaLaboralExternaVM experienciaLaboralVM = new ExperienciaLaboralExternaVM();
            ExperienciaLaboralExternaDomainModel experienciaLaboral = experienciaLaboralExterna.GetExperienciaLaboral(idDocumento, idPersonal);

            if (experienciaLaboral != null)
            {
                AutoMapper.Mapper.Map(experienciaLaboral, experienciaLaboralVM);
                return PartialView("_Editar", experienciaLaboralVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de actualizar un objeto de la base de datos.
        /// </summary>
        /// <param name="experienciaLaboralExternaVM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditExperiencia(ExperienciaLaboralExternaVM experienciaLaboralExternaVM)
        {

            ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();

            AutoMapper.Mapper.Map(experienciaLaboralExternaVM, experienciaLaboralDM);

            if (experienciaLaboralDM.id > 0)
            {
                experienciaLaboralExterna.AddUpdateExperiencia(experienciaLaboralDM);
            }

            return RedirectToAction("Create","ExperienciaLaboralExterna");
        }

    }
}