﻿using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Repository.Infraestructure.Contract;
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
    public class ProyectoInvestigacionController : Controller
    {
        List list = new List();
        IUnitOfWork unitOfWork;
        IDocumentosBusiness documentosBusiness;
        IProyectoInvestigacionBusiness proyectoInvestigacionBusiness;

        public ProyectoInvestigacionController(IUnitOfWork _unitofWork,IDocumentosBusiness _documentosBusiness,
            IProyectoInvestigacionBusiness _proyectoInvestigacionBusiness)
        {
            unitOfWork = _unitofWork;
            documentosBusiness = _documentosBusiness;
            proyectoInvestigacionBusiness = _proyectoInvestigacionBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoPatrocinador = new SelectList(list.FllTipoPatrocinador());
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        [HttpPost]
        public ActionResult Create(ProyectoInvestigacionVM proyectoInvestigacionVM)
        {
            if (ModelState.IsValid)
            {
                ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                proyectoInvestigacionVM.idPersonal = idPersonal;

                AutoMapper.Mapper.Map(proyectoInvestigacionVM,proyectoInvestigacionDM);

                object[] obj = CrearDocumentoPersonales(proyectoInvestigacionVM);

                if (obj[0].Equals(true))
                {
                    proyectoInvestigacionDM.documentos = new DocumentosDomainModel { StrUrl = obj[1].ToString()};    
                    proyectoInvestigacionBusiness.AddUpdateProyectoInvestigacion(proyectoInvestigacionDM);
                }

            }

            return RedirectToAction("Create","ProyectoInvestigacion");
        }

        private Object[] CrearDocumentoPersonales(ProyectoInvestigacionVM proyectoInvestigacionVM)
        {
            Object[] respuesta = new Object[2];
            proyectoInvestigacionVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (proyectoInvestigacionVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, proyectoInvestigacionVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(proyectoInvestigacionVM);
            }

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetProyectos(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ProyectoInvestigacionDomainModel> proyectos = new List<ProyectoInvestigacionDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                proyectos = proyectoInvestigacionBusiness.GetProyectosByIdPersonal(IdentityPersonal).Where(p => p.strTituloProyecto.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = proyectoInvestigacionBusiness.GetProyectosByIdPersonal(IdentityPersonal).Count();


                proyectos = proyectoInvestigacionBusiness.GetProyectosByIdPersonal(IdentityPersonal).OrderBy(p => p.strTituloProyecto)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = proyectos,
                sEcho = param.sEcho,
                iTotalDisplayRecords = proyectos.Count(),
                iTotalRecords = proyectos.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProyectoDelete(int _idProyecto)
        {

            ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();
            proyectoInvestigacionDM = proyectoInvestigacionBusiness.GetProyectoById(_idProyecto);

            if (proyectoInvestigacionDM != null)
            {
                ProyectoInvestigacionVM proyectoInvestigacionVM = new ProyectoInvestigacionVM();

                AutoMapper.Mapper.Map(proyectoInvestigacionDM,proyectoInvestigacionVM);

                return PartialView("_Eliminar",proyectoInvestigacionVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteProyecto(ProyectoInvestigacionVM proyectoInvestigacionVM)
        {
            ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

            proyectoInvestigacionDM = proyectoInvestigacionBusiness.GetProyectoById(proyectoInvestigacionVM.id);

            if (proyectoInvestigacionDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + proyectoInvestigacionDM.documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(proyectoInvestigacionDM.idDocumento);
                }              
            }

            return RedirectToAction("Create","ProyectoInvestigacion");
        }

        [HttpGet]
        public ActionResult GetProyectoUpdate(int _idProyecto)
        {
            ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

            proyectoInvestigacionDM = proyectoInvestigacionBusiness.GetProyectoById(_idProyecto);

            if (proyectoInvestigacionDM != null)
            {

                ProyectoInvestigacionVM proyectoInvestigacionVM = new ProyectoInvestigacionVM();

                AutoMapper.Mapper.Map(proyectoInvestigacionDM,proyectoInvestigacionVM);

                return PartialView("_Editar",proyectoInvestigacionVM);

            }

            return PartialView(); 
        }

        [HttpPost]
        public ActionResult UpdateProyecto(ProyectoInvestigacionVM proyectoInvestigacionVM)
        {

            if (proyectoInvestigacionVM.id > 0)
            {
                ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

                AutoMapper.Mapper.Map(proyectoInvestigacionVM, proyectoInvestigacionDM);
                proyectoInvestigacionBusiness.AddUpdateProyectoInvestigacion(proyectoInvestigacionDM);
            }

            return RedirectToAction("Create","ProyectoInvestigacion");
        }

    }
}