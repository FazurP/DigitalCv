using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository.Infraestructure.Contract;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class PrototipoController : Controller
    {
        IPaisBusiness paisBusiness;
        IUnitOfWork unitofWork;
        IDocumentosBusiness documentosBusiness;
        List list = new List();

        public PrototipoController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IDocumentosBusiness _documentosBusiness)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            documentosBusiness = _documentosBusiness;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoPrototipo = new SelectList(list.FillTipoPrototipo());
                ViewBag.strEstadoActual = new SelectList(list.FillEstado());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(),"idPais","strValor");
                ViewBag.strProposito = new SelectList(list.FillProposito());
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }
    }
}