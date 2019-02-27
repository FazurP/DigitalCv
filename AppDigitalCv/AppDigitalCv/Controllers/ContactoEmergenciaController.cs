using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ContactoEmergenciaController : Controller
    {
        IParentescoBusiness IparentescoBusiness;
        public ContactoEmergenciaController(IParentescoBusiness _IparentescoBusiness)
        {
            IparentescoBusiness = _IparentescoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            return View();
        }
    }
}