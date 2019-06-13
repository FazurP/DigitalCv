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
                if (experienciaLaboralExternaVM.dteFechaInicio <= experienciaLaboralExternaVM.dteFechaFinal)
                {
                    ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();
                    DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();
                    AutoMapper.Mapper.Map(experienciaLaboralExternaVM, experienciaLaboralDM);
                    AutoMapper.Mapper.Map(experienciaLaboralExternaVM.documentosVM, documentosDomainModel);
                    experienciaLaboralDM.documentosDM = documentosDomainModel;

                    if (GuardarArchivo(experienciaLaboralDM, nombre))
                    {
                        experienciaLaboralDM.documentosDM.StrUrl = experienciaLaboralDM.documentosDM.DocumentoFile.FileName;
                        DocumentosDomainModel documentos = documentosBusiness.AddDocumento(documentosDomainModel);
                        experienciaLaboralDM.idDocumento = documentos.IdDocumento;
                        experienciaLaboralExterna.AddUpdateExperiencia(experienciaLaboralDM);

                    }
                }
                else
                {
                    ViewBag.ErrorFechaComparacion = Recursos.RecursosSistema.ERROR_COMPARACION_FECHA;
                }
            }
            return RedirectToAction("Create", "ExperienciaLaboralExterna");
        }
        /// <summary>
        /// Este metodo se encarga de guardar el archivo en la ruta del servidor
        /// </summary>
        /// <param name="experienciaDM"></param>
        /// <param name="nombre"></param>
        /// <returns>true o false</returns>
        private bool GuardarArchivo(ExperienciaLaboralExternaDomainModel experienciaDM, string nombre)
        {
            bool respuesta = false;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));
            if (Directory.Exists(path))
            {
                if (experienciaDM.documentosDM.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pathCompleto = Path.Combine(path,Path.GetFileName(experienciaDM.documentosDM.DocumentoFile.FileName));
                    experienciaDM.documentosDM.DocumentoFile.SaveAs(pathCompleto);
                    respuesta = true;
                }
            }
            return respuesta;
        }

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
        [HttpPost]
        public ActionResult DeleteExperiencia(ExperienciaLaboralExternaVM experienciaVM)
        {
            ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();

            experienciaLaboralDM = experienciaLaboralExterna.GetExperienciaLaboral(experienciaVM.idDocumento, experienciaVM.idPersonal);

            if (experienciaLaboralDM != null)
            {
                documentosBusiness.DeleteDocumento(experienciaVM.idDocumento);
            }

                
            return RedirectToAction("Create","ExperienciaLaboralExterna");
        }

        [HttpGet]
        public ActionResult GetExperenciaEdit(int idDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ExperienciaLaboralExternaVM experienciaLaboralVM = new ExperienciaLaboralExternaVM();
            ExperienciaLaboralExternaDomainModel experienciaLaboral = experienciaLaboralExterna.GetExperienciaLaboralEdit(idDocumento, idPersonal);

            if (experienciaLaboral != null)
            {
                AutoMapper.Mapper.Map(experienciaLaboral, experienciaLaboralVM);
                return PartialView("_Editar", experienciaLaboralVM);
            }

            return View();
        }
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