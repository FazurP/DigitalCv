using AppDigitalCv.Business.Enum;
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
    public class LibroController : Controller
    {
        ILibroBusiness libroBusiness;
        IPaisBusiness paisBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public LibroController(ILibroBusiness _libroBusiness, IPaisBusiness _paisBusiness, IProgresoProdep _progresoProdep)
        {
            libroBusiness = _libroBusiness;
            paisBusiness = _paisBusiness;
            progresoProdep = _progresoProdep;
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

        [HttpPost]
        public ActionResult Create(LibroVM libroVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateLibro(libroVM);
            }

            return RedirectToAction("Create", "Libro");
        }

        public bool AddUpdateLibro(LibroVM libroVM)
        {
            bool respuesta = false;
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_LIBRO);

            libroVM.idPersonal = idPersonal;
            libroVM.idStatus = idStatus;

            LibroDomainModel libroDM = new LibroDomainModel();
            ProgresoProdepVM progresoProdepVM = new ProgresoProdepVM();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepVM.idPersonal = idPersonal;
            progresoProdepVM.idStatus = idStatus;


            AutoMapper.Mapper.Map(progresoProdepVM,progresoProdepDM);
            AutoMapper.Mapper.Map(libroVM,libroDM);
            libroBusiness.AddUpdateLibro(libroDM);
            progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
            respuesta = true;
            return respuesta;
        }

    }
}