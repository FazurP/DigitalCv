using AppDigitalCv.Business.Interface;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class AlergiasController : Controller
    {
        IAlergiasBusiness alergiasBusiness;

        public AlergiasController(IAlergiasBusiness _alergiasBusiness)
        {
            alergiasBusiness = _alergiasBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Alimentos = new SelectList(alergiasBusiness.GetAlergias(), "IdAlergia", "StrDescripcion");
                ViewBag.Alergenos = new SelectList(alergiasBusiness.GetAlergenos(), "IdAlergia", "StrDescripcion");
                ViewBag.Medicamentos = new SelectList(alergiasBusiness.GetMedicamentos(), "IdAlergia", "StrDescripcion");
                return View();
            }
            else
            {
               return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }
    }
}