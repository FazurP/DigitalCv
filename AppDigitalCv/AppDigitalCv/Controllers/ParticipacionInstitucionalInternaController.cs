﻿using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ParticipacionInstitucionalInternaController : Controller
    {
        IPeriodoBusiness periodoBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        ITipoActividad tipoActividad;
        IDocumentosBusiness documentosBusiness;
        IParticipacionInstitucionalInternaBusiness participacionInstitucionalInternaBusiness;
        public ParticipacionInstitucionalInternaController(IProgramaEducativoBusiness _programaEducativoBusiness,
            IPeriodoBusiness _periodoBusiness, ITipoActividad _tipoActividad, IDocumentosBusiness _documentosBusiness
            , IParticipacionInstitucionalInternaBusiness _participacionInstitucionalInternaBusiness)
        {
            programaEducativoBusiness = _programaEducativoBusiness;
            tipoActividad = _tipoActividad;
            periodoBusiness = _periodoBusiness;
            documentosBusiness = _documentosBusiness;
            participacionInstitucionalInternaBusiness = _participacionInstitucionalInternaBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idCatProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.idCatTipoActividad = new SelectList(tipoActividad.GetTiposActividades(), "id", "strDescripcion");
                ViewBag.idCatPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");
                return View();
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }
           
        }

        [HttpPost]
        public ActionResult Create (ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {
            if (ModelState.IsValid)
            {
                CrearDocumentoPersonales(institucionalInternaVM);
            }
            return RedirectToAction("Create","ParticipacionInstitucionalInterna");
        }

        public void CrearDocumentoPersonales(ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {

            institucionalInternaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);

                if (institucionalInternaVM.documentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(institucionalInternaVM.documentosVM.DocumentoFile.FileName));
                    string sfpath = institucionalInternaVM.documentosVM.DocumentoFile.FileName;
                    institucionalInternaVM.documentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    institucionalInternaVM.documentosVM = documentoVM;
                }


                this.AddUpdatePartipacionInstitucionalInterna(institucionalInternaVM);
            }
            else
            {
                if (institucionalInternaVM.documentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(institucionalInternaVM.documentosVM.DocumentoFile.FileName));
                    string sfpath = institucionalInternaVM.documentosVM.DocumentoFile.FileName;
                    institucionalInternaVM.documentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    institucionalInternaVM.documentosVM = documentoVM;
                }

                this.AddUpdatePartipacionInstitucionalInterna(institucionalInternaVM);
            }
        }

        public bool AddUpdatePartipacionInstitucionalInterna(ParticipacionInstitucionalInternaVM institucionalInternaVM)
        {
            bool respuesta = false;

            ParticipacionInstitucionalInternaDomainModel participacionInstitucionalInternaDM = new ParticipacionInstitucionalInternaDomainModel();
            DocumentosDomainModel documentosDM = new DocumentosDomainModel();

            AutoMapper.Mapper.Map(institucionalInternaVM, participacionInstitucionalInternaDM);
            AutoMapper.Mapper.Map(institucionalInternaVM.documentosVM, documentosDM);
            participacionInstitucionalInternaDM.documentosDM = documentosDM;

            DocumentosDomainModel documento = documentosBusiness.AddUpdateDocumento(documentosDM);
            participacionInstitucionalInternaDM.idCatDocumento = documento.IdDocumento;
            respuesta = participacionInstitucionalInternaBusiness.AddUpdateParticipacion(participacionInstitucionalInternaDM);
            return respuesta;
        }
        [HttpGet]
        public JsonResult GetParticipaciones(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ParticipacionInstitucionalInternaDomainModel> participacionDM = new List<ParticipacionInstitucionalInternaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                participacionDM = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Where(p => p.strActividad.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).Count();


                participacionDM = participacionInstitucionalInternaBusiness.GetParticipacionesPersonalesById(IdentityPersonal).OrderBy(p => p.strActividad)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = participacionDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = participacionDM.Count(),
                iTotalRecords = participacionDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        #region Metodos para la eliminacion
        [HttpGet]
        public ActionResult GetParticipacionById(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
                participacionInstitucionalInternaBusiness.GetParticipacion(idPersonal, idCatDocumento);

            if (participacionDM != null)
            {
                ParticipacionInstitucionalInternaVM participacionVM = new ParticipacionInstitucionalInternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Eliminar", participacionVM);
            }

            return View();
        }        
        [HttpPost]
        public ActionResult DeleteParticipacion(ParticipacionInstitucionalInternaVM participacionVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
                participacionInstitucionalInternaBusiness.GetParticipacion(idPersonal, participacionVM.idCatDocumento);

            if (participacionDM != null)
            {
                documentosBusiness.DeleteDocumento(participacionVM.idCatDocumento);
            }

            return View(Create());
        }
        #endregion
        #region Metodos para la Actualizacion
        [HttpGet]
        public ActionResult GetParticipacionByIdEdit(int idCatDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            ParticipacionInstitucionalInternaDomainModel participacionDM =
              participacionInstitucionalInternaBusiness.GetParticipacionEdit(idPersonal, idCatDocumento);
            if (participacionDM != null)
            {

                ViewBag.idCatProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.idCatTipoActividad = new SelectList(tipoActividad.GetTiposActividades(), "id", "strDescripcion");
                ViewBag.idCatPeriodo = new SelectList(periodoBusiness.GetPeriodos(), "id", "strDescripcion");
            
                ParticipacionInstitucionalExternaVM participacionVM = new ParticipacionInstitucionalExternaVM();
                AutoMapper.Mapper.Map(participacionDM, participacionVM);
                return PartialView("_Editar", participacionVM);
            }
            return View();

        }
        [HttpPost]
        public void EditarParticipacionPersonal(ParticipacionInstitucionalInternaVM participacionInstitucionalInternaVM)
        {

            ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();
            AutoMapper.Mapper.Map(participacionInstitucionalInternaVM, participacionDM);

            if (participacionInstitucionalInternaVM.id > 0)
            {
                participacionInstitucionalInternaBusiness.AddUpdateParticipacion(participacionDM);

            }

        }
        #endregion
    }
}