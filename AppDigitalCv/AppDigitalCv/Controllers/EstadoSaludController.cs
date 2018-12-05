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
        ITipoSangreBusiness ItipoSangreBusiness;
        public EstadoSaludController(IEnfermedadBusiness _IenfermedadesBusiness, ITipoSangreBusiness _itipoSangreBusiness)
        {
            IenfermedadesBusiness = _IenfermedadesBusiness;
            ItipoSangreBusiness = _itipoSangreBusiness;
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
            ViewBag.TipoSangre = new SelectList(ItipoSangreBusiness.GetTipoSangre(), "IdTipoSangre", "StrDescripcion");
            return View();
        }
    }
}