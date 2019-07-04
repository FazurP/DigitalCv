using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
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
        IProgresoProdep progresoProdep;

        public ManualOperacionController(IManualOperacionBusiness _operacionBusiness,IPaisBusiness _paisBusiness,IProgresoProdep _progresoProdep)
        {

            operacionBusiness = _operacionBusiness;
            paisBusiness = _paisBusiness;
            progresoProdep = _progresoProdep;

        }
        [HttpGet]
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
        [HttpPost]
        public ActionResult Create(ManualOperacionVM manualOperacionVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateManualOperacion(manualOperacionVM);
            }

            return RedirectToAction("Create", "ManualOperacion");
        }

        public bool AddUpdateManualOperacion(ManualOperacionVM manualOperacionVM)
        {
            bool respuesta = false;
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_MANUAL_OPERACION);

            manualOperacionVM.idPersonal = idPersonal;
            manualOperacionVM.idStatus = idStatus;

            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepDM.idPersonal = idPersonal;
            progresoProdepDM.idStatus = idStatus;

            AutoMapper.Mapper.Map(manualOperacionVM,manualOperacionDM);

            operacionBusiness.AddUpdateManualOperacion(manualOperacionDM);
            respuesta = progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);

            return respuesta;
        }
    }
}