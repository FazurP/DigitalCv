using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ExperienciaLaboralInternaController : Controller
    {

        IAreaBusiness areaBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        ITipoContratoBusiness tipoContratoBusiness;
        ICategoriaBusiness categoriaBusiness;
        IPeriodoBusiness periodoBusiness;
        IExperienciaLaboralInternaBusiness ExperienciaLaboralInternaBusiness;

        public ExperienciaLaboralInternaController(IAreaBusiness _areaBusiness, IProgramaEducativoBusiness _programaEducativoBusiness,
            ITipoContratoBusiness _tipoContratoBusiness, ICategoriaBusiness _categoriaBusiness, IPeriodoBusiness _periodoBusiness
            , IExperienciaLaboralInternaBusiness _experienciaLaboralInternaBusiness)
        {
            areaBusiness = _areaBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            tipoContratoBusiness = _tipoContratoBusiness;
            categoriaBusiness = _categoriaBusiness;
            periodoBusiness = _periodoBusiness;
            ExperienciaLaboralInternaBusiness = _experienciaLaboralInternaBusiness;
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idCategoria = new SelectList(categoriaBusiness.GetCategorias(), "idCategoria", "strDescripcion");
                ViewBag.idTipoContrato = new SelectList("");
                ViewBag.idArea = new SelectList(areaBusiness.GetAreas(),"idArea","strDescripcion");
                ViewBag.idProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(),"idProgramaEducativo","strDescripcion");
                ViewBag.idPeriodo = new SelectList(periodoBusiness.GetPeriodos(),"id","strDescripcion");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }        
        }

        [HttpPost]
        public ActionResult Create(ExperienciaLaboralInternaVM experienciaLaboralInternaVM)
        {
            if (ModelState.IsValid)
            {
                if (experienciaLaboralInternaVM.dteFechaTermino > experienciaLaboralInternaVM.dteFechaInicio)
                {
                    this.AddUpdateExperienciaLaboralInterna(experienciaLaboralInternaVM);
                }
               
            }
            return RedirectToAction("Create","ExperienciaLaboralInterna");
        }

        public bool AddUpdateExperienciaLaboralInterna(ExperienciaLaboralInternaVM experienciaLaboralInternaVM)
        {
            experienciaLaboralInternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            bool respuesta = false;
            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = new ExperienciaLaboralInternaDomainModel();

            AutoMapper.Mapper.Map(experienciaLaboralInternaVM, experienciaLaboralInternaDM);
            ExperienciaLaboralInternaBusiness.AddUpdateExperienciaLaboralInterna(experienciaLaboralInternaDM);
            respuesta = true;
            return respuesta;
        }

        [HttpPost]
        public ActionResult GetTipoContratoByCategoria(int idCategoria)
        {
            List<TipoContratoDomainModel> tipoContrato = tipoContratoBusiness.GetTiposContratoById(idCategoria);
            List<TipoContratoVM> tipoContratoVM = new List<TipoContratoVM>();

            AutoMapper.Mapper.Map(tipoContrato, tipoContratoVM);
            ViewBag.idTipoContrato = new SelectList(tipoContratoVM, "idTipoContrato", "strDescripcion");
            return PartialView("_TipoDeContrato");
        }

        [HttpGet]
        public JsonResult GetExperiencias(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ExperienciaLaboralInternaDomainModel> experienciaDM = new List<ExperienciaLaboralInternaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                experienciaDM = ExperienciaLaboralInternaBusiness.GetExperienciasByPersonal(IdentityPersonal).Where(p => p.strActividadDesempeñada.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = ExperienciaLaboralInternaBusiness.GetExperienciasByPersonal(IdentityPersonal).Count();


                experienciaDM = ExperienciaLaboralInternaBusiness.GetExperienciasByPersonal(IdentityPersonal).OrderBy(p => p.strActividadDesempeñada)
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
        public ActionResult GetExperiencia(int _idExperiencia)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = ExperienciaLaboralInternaBusiness.GetExperiencia(idPersonal, _idExperiencia);
            ExperienciaLaboralInternaVM experienciaLaboralInternaVM = new ExperienciaLaboralInternaVM();

            if (experienciaLaboralInternaDM != null)
            {
                AutoMapper.Mapper.Map(experienciaLaboralInternaDM, experienciaLaboralInternaVM);
                return PartialView("_Eliminar", experienciaLaboralInternaVM);
            }

            return View();
        }
        [HttpPost]
        public ActionResult DeleteExperiencia(ExperienciaLaboralInternaVM experienciaLaboralInternaVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;

            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = ExperienciaLaboralInternaBusiness.GetExperiencia(idPersonal,experienciaLaboralInternaVM.id);

            if (experienciaLaboralInternaDM != null)
            {
                ExperienciaLaboralInternaBusiness.DeleteExperiencias(idPersonal, experienciaLaboralInternaDM.id);
            }

            return View();
        }
        [HttpGet]
        public ActionResult GetExperienciaEdit(int _idExperiencia)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = ExperienciaLaboralInternaBusiness.GetExperiencia(idPersonal, _idExperiencia);
            ExperienciaLaboralInternaVM experienciaLaboralInternaVM = new ExperienciaLaboralInternaVM();

            if (experienciaLaboralInternaDM != null)
            {
                AutoMapper.Mapper.Map(experienciaLaboralInternaDM, experienciaLaboralInternaVM);
                return PartialView("_Editar", experienciaLaboralInternaVM);
            }

            return View();
        }
        [HttpPost]
        public ActionResult EditExperiencia(ExperienciaLaboralInternaVM experienciaLaboralInternaVM)
        {

            int idPersonal = SessionPersister.AccountSession.IdPersonal;

            ExperienciaLaboralInternaDomainModel experienciaDM = new ExperienciaLaboralInternaDomainModel();

            if (experienciaLaboralInternaVM.id > 0)
            {
                AutoMapper.Mapper.Map(experienciaLaboralInternaVM, experienciaDM);

                ExperienciaLaboralInternaBusiness.AddUpdateExperienciaLaboralInterna(experienciaDM);
            }

            return View();
        }

    }
}