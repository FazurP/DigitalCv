using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class EstadoSaludController : Controller
    {
        IEnfermedadBusiness IenfermedadesBusiness;

        public EstadoSaludController(IEnfermedadBusiness _IenfermedadesBusiness)
        {
            IenfermedadesBusiness = _IenfermedadesBusiness;
        }

        // GET: EstadoSalud
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Enfermedades = new SelectList(IenfermedadesBusiness.GetEnfermedades(), "IdEnfermedad", "StrDescripcion");
            return View();
        }
    }
}