using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class CursoController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrDescripcion")] CursoVM cursoVM)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
    }
}