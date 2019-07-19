using AppDigitalCv.Business.Enum;
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
        IProgresoProdep progresoProdep;

        public ProyectoInvestigacionController(IUnitOfWork _unitofWork,IDocumentosBusiness _documentosBusiness,
            IProyectoInvestigacionBusiness _proyectoInvestigacionBusiness,IProgresoProdep _progresoProdep)
        {
            unitOfWork = _unitofWork;
            documentosBusiness = _documentosBusiness;
            proyectoInvestigacionBusiness = _proyectoInvestigacionBusiness;
            progresoProdep = _progresoProdep;
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
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();
                DocumentosDomainModel documentoDMResumen = new DocumentosDomainModel();
                DocumentosDomainModel documentoDMReseña = new DocumentosDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_PROYECTO_INVESTIGACION);

                proyectoInvestigacionVM.idPersonal = idPersonal;
                proyectoInvestigacionVM.idStatus = idStatus;

                AutoMapper.Mapper.Map(proyectoInvestigacionVM,proyectoInvestigacionDM);
                AutoMapper.Mapper.Map(proyectoInvestigacionVM.documentosVMResumen, documentoDMResumen);
                AutoMapper.Mapper.Map(proyectoInvestigacionVM.documentosVMReseña, documentoDMReseña);
                proyectoInvestigacionDM.documentosDMResumen = documentoDMResumen;
                proyectoInvestigacionDM.documentosDMReseña = documentoDMReseña;

                if (GuadarArchivo(proyectoInvestigacionDM,nombre))
                {
                    proyectoInvestigacionDM.documentosDMResumen.StrUrl = proyectoInvestigacionDM.documentosDMResumen.DocumentoFile.FileName;
                    proyectoInvestigacionDM.documentosDMReseña.StrUrl = proyectoInvestigacionDM.documentosDMReseña.DocumentoFile.FileName;
                    DocumentosDomainModel documentosDMResumen = documentosBusiness.AddDocumento(documentoDMResumen);
                    DocumentosDomainModel documentosDMReseña = documentosBusiness.AddDocumento(documentoDMReseña);
                    proyectoInvestigacionDM.idDocumento = documentosDMResumen.IdDocumento;
                    proyectoInvestigacionBusiness.AddUpdateProyectoInvestigacion(proyectoInvestigacionDM);
                    proyectoInvestigacionDM.idDocumento = documentosDMReseña.IdDocumento;
                    proyectoInvestigacionBusiness.AddUpdateProyectoInvestigacion(proyectoInvestigacionDM);
                    progresoProdepDM.idPersonal = idPersonal;
                    progresoProdepDM.idStatus = idStatus;
                    progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
                }

            }

            return RedirectToAction("Create","ProyectoInvestigacion");
        }

        public bool GuadarArchivo(ProyectoInvestigacionDomainModel proyectoInvestigacionDM, string nombre)
        {
            bool respuesta = false;

            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));

            if (Directory.Exists(path))
            {
                if (proyectoInvestigacionDM.documentosDMResumen.DocumentoFile.ContentType.Equals("application/pdf")
                    && proyectoInvestigacionDM.documentosDMReseña.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pahtCompletoResumen = Path.Combine(path, Path.GetFileName(proyectoInvestigacionDM.documentosDMResumen.DocumentoFile.FileName));
                    proyectoInvestigacionDM.documentosDMResumen.DocumentoFile.SaveAs(pahtCompletoResumen);

                    string pathCompletoReseña = Path.Combine(path, Path.GetFileName(proyectoInvestigacionDM.documentosDMReseña.DocumentoFile.FileName));
                    proyectoInvestigacionDM.documentosDMReseña.DocumentoFile.SaveAs(pathCompletoReseña);

                    respuesta = true;
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                GuadarArchivo(proyectoInvestigacionDM, nombre);
                respuesta = true;
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

    }
}