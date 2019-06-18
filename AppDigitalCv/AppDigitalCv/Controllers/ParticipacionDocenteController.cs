using AppDigitalCv.Business.Interface;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ParticipacionDocenteController : Controller
    {
        IParticipacionDocenteBusiness IparticipacionDocenteBusiness;

        public ParticipacionDocenteController(IParticipacionDocenteBusiness iparticipacionDocenteBusiness)
        {
            IparticipacionDocenteBusiness = iparticipacionDocenteBusiness;
        }

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

    }
}