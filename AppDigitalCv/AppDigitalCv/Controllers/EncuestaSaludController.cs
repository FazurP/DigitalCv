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
    public class EncuestaSaludController : Controller
    {
        IEncuestaSaludBusiness encuestaSaludBusiness;
    
        public EncuestaSaludController(IEncuestaSaludBusiness _encuestaSaludBusiness) 
        {
            encuestaSaludBusiness = _encuestaSaludBusiness;
        }

        [HttpGet]
        public ActionResult Create() 
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewData["Respuestas04.idOpcion"] = new SelectList(encuestaSaludBusiness.GetAllOpcionesRespuesta04(), "id", "strValor");
                ViewData["Respuestas05.idRh"] = new SelectList(encuestaSaludBusiness.GetAllRhs(), "id", "strValor");
                ViewData["Respuestas05.idGrupoSanguineo"] = new SelectList(encuestaSaludBusiness.GetAllGruposSanguineos(), "id", "strValor");

                return View();
            }
            return RedirectToAction("Login", "Seguridad");
        }

        [HttpPost]
        public ActionResult Create(EncuestaVM encuestaVM)
        {
            encuestaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

            EncuestaDomainModel encuestaDomainModel = new EncuestaDomainModel();

            AutoMapper.Mapper.Map(encuestaVM, encuestaDomainModel);

            encuestaSaludBusiness.AddEncuesta(encuestaDomainModel);

            return RedirectToAction("Create","EncuestaSalud");
        }
    }
}