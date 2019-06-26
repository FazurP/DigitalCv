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
        /// <summary>
        /// Este metodo se encarga de cargar la vista principal
        /// </summary>
        /// <returns>una vista</returns>
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
        /// <summary>
        /// Este metodo se encarga de recibir los datos ingresados por el usuario y de validar que los mismos
        /// sean validos
        /// </summary>
        /// <param name="experienciaLaboralInternaVM"></param>
        /// <returns>una vista</returns>
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
        /// <summary>
        /// Este metodo se encarga de mappear los datos y insertarlos en la base de datos.
        /// </summary>
        /// <param name="experienciaLaboralInternaVM"></param>
        /// <returns>true o false</returns>
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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pintarlo en una vista parcial de un DropDawnList
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns>Una vista parcial con el objeto</returns>
        [HttpPost]
        public ActionResult GetTipoContratoByCategoria(int idCategoria)
        {
            List<TipoContratoDomainModel> tipoContrato = tipoContratoBusiness.GetTiposContratoById(idCategoria);
            List<TipoContratoVM> tipoContratoVM = new List<TipoContratoVM>();

            AutoMapper.Mapper.Map(tipoContrato, tipoContratoVM);
            ViewBag.idTipoContrato = new SelectList(tipoContratoVM, "idTipoContrato", "strDescripcion");
            return PartialView("_TipoDeContrato");
        }
        /// <summary>
        /// Este metodo se encarga de cargar y mostrar los objetos correspondientes de la persona en la tabla
        /// </summary>
        /// <param name="param"></param>
        /// <returns>un Json con los objetos</returns>
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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Eliminar
        /// </summary>
        /// <param name="_idExperiencia"></param>
        /// <returns>una vista parcial con el obejto</returns>
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
        /// <summary>
        /// Este  metodo se encarga de eliminar un objeto de la base de datos
        /// </summary>
        /// <param name="experienciaLaboralInternaVM"></param>
        /// <returns>una vista</returns>
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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto y pasarlo a la vista parcial _Editar
        /// </summary>
        /// <param name="_idExperiencia"></param>
        /// <returns>una vista parcial con el objeto</returns>
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
        /// <summary>
        /// Este metodo se encarga de actualizar un objeto de la base de datos.
        /// </summary>
        /// <param name="experienciaLaboralInternaVM"></param>
        /// <returns></returns>
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