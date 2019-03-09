using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class HabitosPersonalesController : Controller
    {
        IDeporteBusiness deporteBusiness;
        public HabitosPersonalesController(IDeporteBusiness _deporteBusiness)
        {
            deporteBusiness = _deporteBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdDeportes = new SelectList(deporteBusiness.GetDeportes(), "IdDeporte", "StrDescripcion");
            return View();
        }
    }
}

