using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DatosFamiliaresController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrNombre,StrOcupacion,StrDomicilio,IntEdad,BitVive")]FamiliaresVM familiaresVM)
        {
            return View();
        }


    }
}