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
    public class ExperienciaLaboralInternaController : Controller
    {

        IAreaBusiness areaBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        ITipoContratoBusiness tipoContratoBusiness;
        ICategoriaBusiness categoriaBusiness;
        IPeriodoBusiness periodoBusiness;

        public ExperienciaLaboralInternaController(IAreaBusiness _areaBusiness, IProgramaEducativoBusiness _programaEducativoBusiness,
            ITipoContratoBusiness _tipoContratoBusiness, ICategoriaBusiness _categoriaBusiness, IPeriodoBusiness _periodoBusiness)
        {
            areaBusiness = _areaBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            tipoContratoBusiness = _tipoContratoBusiness;
            categoriaBusiness = _categoriaBusiness;
            periodoBusiness = _periodoBusiness;
        }
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idCategoria = new SelectList(categoriaBusiness.GetCategorias(), "idCategoria", "strDescripcion");
                ViewBag.idTipoContrato = new SelectList("");

                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        [HttpPost]
        public ActionResult GetTipoContratoByCategoria(int idCategoria)
        {
            List<TipoContratoDomainModel> tipoContrato = tipoContratoBusiness.GetTiposContratoById(idCategoria);
            List<TipoContratoVM> tipoContratoVM = new List<TipoContratoVM>();

            AutoMapper.Mapper.Map(tipoContrato,tipoContratoVM);
            ViewBag.idTipoContrato = new SelectList(tipoContratoVM,"idTipoContrato","strDescripcion");
            return PartialView("_TipoContrato");
        }
    }
}