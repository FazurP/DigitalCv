using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class HistorialAcademicoController : Controller
    {
        // GET: HistorialAcademico
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}