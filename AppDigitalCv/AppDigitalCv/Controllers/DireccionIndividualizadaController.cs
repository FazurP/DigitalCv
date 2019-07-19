using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DireccionIndividualizadaController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperior;
        ITipoEstudioBusiness tipoEstudioBusiness;
        IDireccionIndividualizadaBusiness direccionIndividualizadaBusiness;

        public DireccionIndividualizadaController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness, ITipoEstudioBusiness _tipoEstudioBusiness,
            IDireccionIndividualizadaBusiness _direccionIndividualizadaBusiness)
        {
            institucionSuperior = _institucionSuperiorBusiness;
            tipoEstudioBusiness = _tipoEstudioBusiness;
            direccionIndividualizadaBusiness = _direccionIndividualizadaBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}