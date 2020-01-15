﻿using AppDigitalCv.Business.Interface;
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
    public class HistorialAcademicoController : Controller
    {

        IInstitucionAcreditaDoctoradoBusiness institucionAcreditaDoctorado;
        IInstitucionAcreditaLicenciaturaBusiness institucionAcreditaLicenciaturaBusiness;
        IStatusDoctoradoBusiness statusDoctorado;
        IFuenteFinaciamientoDoctoradoBusiness fuenteFinaciamientoDoctoradoBusiness;

        public HistorialAcademicoController(IInstitucionAcreditaDoctoradoBusiness _institucionAcreditaDoctorado,
            IInstitucionAcreditaLicenciaturaBusiness _institucionAcreditaLicenciaturaBusiness,
            IStatusDoctoradoBusiness _statusDoctorado,
            IFuenteFinaciamientoDoctoradoBusiness _fuenteFinaciamientoDoctoradoBusiness)
        {
            institucionAcreditaDoctorado = _institucionAcreditaDoctorado;
            institucionAcreditaLicenciaturaBusiness = _institucionAcreditaLicenciaturaBusiness;
            statusDoctorado = _statusDoctorado;
            fuenteFinaciamientoDoctoradoBusiness = _fuenteFinaciamientoDoctoradoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login","Seguridad");
            }
            
        }

        [HttpPost]
        public ActionResult Create(HistorialAcademicoVM historialAcademicoVM) 
        {
            switch (historialAcademicoVM.Type)
            {
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
            return RedirectToAction("Create","HistorialAcademico");
        }

        [HttpGet]
        public ActionResult GetInstitucionAcreditanDoctorados()
        {
            List<InstitucionAcreditaDoctoradoDomainModel> institucionAcreditaDoctoradoDomainModels = new List<InstitucionAcreditaDoctoradoDomainModel>();

            institucionAcreditaDoctoradoDomainModels = institucionAcreditaDoctorado.GetAllInstitucionesAcreditanDoctorados();

            List<InstitucionAcreditaDoctoradoVM> institucionAcreditaCapacitacionProfesionalVMs = new List<InstitucionAcreditaDoctoradoVM>();

            AutoMapper.Mapper.Map(institucionAcreditaDoctoradoDomainModels, institucionAcreditaCapacitacionProfesionalVMs);

            ViewBag.InstitucionAcredita = new SelectList(institucionAcreditaCapacitacionProfesionalVMs,"id","strValor");

            return PartialView("_InstitucionesAcreditan");

        }

        [HttpGet]
        public ActionResult GetStatusDoctorados() 
        {
            List<StatusDoctoradoVM> statusDoctoradosVM = new List<StatusDoctoradoVM>();
            List<StatusDoctoradoDomainModel> statusDoctoradosDM = new List<StatusDoctoradoDomainModel>();

            statusDoctoradosDM = statusDoctorado.GetAllStatusDoctorados();

            AutoMapper.Mapper.Map(statusDoctoradosDM,statusDoctoradosVM);

            ViewBag.Status = new SelectList(statusDoctoradosVM, "id", "strValor");

            return PartialView("_StatusDoctorados");
        }

        [HttpGet]
        public ActionResult GetFuentesFinanciamientoDoctorados() 
        {
            List<FuenteFinanciamientoDoctoradoDomainModel> FuenteFinanciamientoDoctoradoDomainModel = new List<FuenteFinanciamientoDoctoradoDomainModel>();
            List<FuenteFinanciamientoDoctoradoVM> FuenteFinanciamientoDoctoradoVM = new List<FuenteFinanciamientoDoctoradoVM>();

            FuenteFinanciamientoDoctoradoDomainModel = fuenteFinaciamientoDoctoradoBusiness.GetAllFuentesFinaciamientosDoctorados();

            AutoMapper.Mapper.Map(FuenteFinanciamientoDoctoradoDomainModel, FuenteFinanciamientoDoctoradoVM);

            ViewBag.FuenteFinaciamiento = new SelectList(FuenteFinanciamientoDoctoradoDomainModel, "id","strValor");

            return PartialView("_FuenteFinaciamientoDoctorado");
        }

        [HttpGet]
        public ActionResult GetInstitucionAcreditanLicenciaturaIng() 
        {
            List<InstitucionAcreditaLicenciaturaDomainModel> institucionAcreditaLicenciaturaDomainModels = new List<InstitucionAcreditaLicenciaturaDomainModel>();
            List<InstitucionAcreditaLicenciaturaVM> institucionAcreditaLicenciaturaVMs = new List<InstitucionAcreditaLicenciaturaVM>();

            institucionAcreditaLicenciaturaDomainModels = institucionAcreditaLicenciaturaBusiness.GetAllInstitucionAcreditanLicenciaturas();

            AutoMapper.Mapper.Map(institucionAcreditaLicenciaturaDomainModels,institucionAcreditaLicenciaturaVMs);

            ViewBag.InstitucionAcreditaLicenciatura = new SelectList(institucionAcreditaLicenciaturaVMs,"id","strValor");

            return PartialView("_InstitucionesAcreditanLicenciatura");
        }
    }
}