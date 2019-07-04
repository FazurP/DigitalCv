using AppDigitalCv.Business.Interface;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ManualOperacionController : Controller
    {
        IManualOperacionBusiness operacionBusiness;
        IPaisBusiness paisBusiness;

        public ManualOperacionController(IManualOperacionBusiness _operacionBusiness,IPaisBusiness _paisBusiness)
        {

            operacionBusiness = _operacionBusiness;
            paisBusiness = _paisBusiness;

        }

        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(),"idPais","strValor");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }
    }
}