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
    public class DireccionIndividualizadaController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperior;
        ITipoEstudioBusiness tipoEstudioBusiness;
        IDireccionIndividualizadaBusiness direccionIndividualizadaBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public DireccionIndividualizadaController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness, ITipoEstudioBusiness _tipoEstudioBusiness,
            IDireccionIndividualizadaBusiness _direccionIndividualizadaBusiness, IProgresoProdep _progresoProdep)
        {
            institucionSuperior = _institucionSuperiorBusiness;
            tipoEstudioBusiness = _tipoEstudioBusiness;
            direccionIndividualizadaBusiness = _direccionIndividualizadaBusiness;
            progresoProdep = _progresoProdep;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoEstudio = new SelectList(tipoEstudioBusiness.GetTiposEstudios(), "idTipoEstudio", "strDescripcion");
                ViewBag.strEstadoDireccionIndividualizada = new SelectList(list.FillEstadoDireccionIndividualizada());
                ViewBag.idInstitucionSuperior = new SelectList(institucionSuperior.GetInstitucionSuperior(), "idInstitucionSuperior", "strDescripcion");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        [HttpPost]
        public ActionResult Create(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateDireccionIndividualizada(direccionIndividualizadaVM);
            }

            return RedirectToAction("Create","DireccionIndividualizada");
        }

        public bool AddUpdateDireccionIndividualizada(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            bool respuesta = false;
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_DIRECCION_INDIVIDUALIZADA);

            direccionIndividualizadaVM.idPersonal = idPersonal;
            direccionIndividualizadaVM.idStatus = idStatus;

            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepDM.idPersonal = idPersonal;
            progresoProdepDM.idStatus = idStatus;

            AutoMapper.Mapper.Map(direccionIndividualizadaVM,direccionIndividualizadaDM);
            direccionIndividualizadaBusiness.AddUpdateDireccionIndividualizada(direccionIndividualizadaDM);
            progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
            respuesta = true;


            return respuesta;

        }
    }
}