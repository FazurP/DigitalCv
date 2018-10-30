using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class PaisController : Controller
    {
        IPaisBusiness IpaisBusiness;

        public PaisController(IPaisBusiness _IpaisBusiness)
        {
            IpaisBusiness = _IpaisBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            //los paises los almacenamos en un viewBag
            ViewBag.Pais = new SelectList(IpaisBusiness.GetPais(), "IdPais", "StrValor");
       
            return View();
        }
    }
}