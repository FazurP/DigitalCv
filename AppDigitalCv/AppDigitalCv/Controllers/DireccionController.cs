using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DireccionController : Controller
    {
        // GET: Direccion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Pais = new SelectList();

            return View("RegistrarDireccion");
        }
    }
}