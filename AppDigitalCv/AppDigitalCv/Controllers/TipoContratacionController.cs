using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class TipoContratacionController : Controller
    {

        ICategoriaBusiness categoriaBusiness;
        IUnidadesAcademicasBusiness unidadesAcademicasBusiness;
        IEdificioBusiness edificioBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        IAreaBusiness areaBusiness;
        ITipoContratoBusiness tipoContratoBusiness;

        public TipoContratacionController(ICategoriaBusiness _categoriaBusiness,
            IUnidadesAcademicasBusiness _unidadesAcademicasBusiness, IEdificioBusiness _edificioBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness, IAreaBusiness _areaBusiness,
            ITipoContratoBusiness _tipoContratoBusiness) {

            categoriaBusiness = _categoriaBusiness;
            unidadesAcademicasBusiness = _unidadesAcademicasBusiness;
            edificioBusiness = _edificioBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            areaBusiness = _areaBusiness;
            tipoContratoBusiness = _tipoContratoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.TipoContratacion = new SelectList(categoriaBusiness.GetCategorias(), "idCategoria", "strDescripcion");
                ViewBag.PuestoDesempeña = new SelectList("");
                ViewBag.Adscripcion = new SelectList(unidadesAcademicasBusiness.GetUnidadesAcademicas(), "idUnidadesAcademicas", "strDescripcion");
                ViewBag.Edificio = new SelectList(edificioBusiness.getEdificios(), "idEdificio", "strDescripcion");
                ViewBag.ProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.Area = new SelectList(areaBusiness.GetAreas(), "idArea", "strDescripcion");
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        //[HttpPost]
        //public ActionResult Create([Bind()])
        //{
        //    return RedirectToAction("Create","TipoContratacion");
        //}

        [HttpPost]
        public ActionResult ConsultarTipoContradoByCategoria(int idCategoria)
        {
            List<TipoContratoDomainModel> ContratosDM = tipoContratoBusiness.GetTiposContratoById(idCategoria);
            List<TipoContratoVM> ContratosVM = new List<TipoContratoVM>();

            AutoMapper.Mapper.Map(ContratosDM, ContratosVM);
            ViewBag.PuestoDesempeña = new SelectList(ContratosVM, "idTipoContrato", "strDescripcion");
            return PartialView("_TipoContrato");
        }
    }
}