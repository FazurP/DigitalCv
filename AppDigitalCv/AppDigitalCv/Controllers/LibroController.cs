using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class LibroController : Controller
    {
        ILibroBusiness libroBusiness;
        IPaisBusiness paisBusiness;
        List list = new List();

        public LibroController(ILibroBusiness _libroBusiness, IPaisBusiness _paisBusiness)
        {
            libroBusiness = _libroBusiness;
            paisBusiness = _paisBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoParticipacion = new SelectList(list.FillTipoParticipacion());
                ViewBag.strEstadoActual = new SelectList(list.FillEstado());
                ViewBag.strProposito = new SelectList(list.FillProposito());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
         
        }

    }
}