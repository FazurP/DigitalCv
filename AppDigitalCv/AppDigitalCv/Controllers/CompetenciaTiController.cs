using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class CompetenciaTiController : Controller
    {
        ICompetenciaBusiness icompetenciaTiBusiness;
        public CompetenciaTiController(ICompetenciaBusiness _competenciaBusiness)
        {
            icompetenciaTiBusiness = _competenciaBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Competenicas = "";
            return View("Create");
        }

    }
}