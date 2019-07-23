using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
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
    public class EstadiaEmpresaController : Controller
    {
        IEstadiaEmpresaBusiness estadiaEmpresaBusiness;
        ITipoProductoBusiness tipoProductoBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        IProgresoProdep progresoProdep;
        IDocumentosBusiness documentosBusiness;
        List list = new List();

        public EstadiaEmpresaController(IEstadiaEmpresaBusiness _estadiaEmpresaBusiness,ITipoProductoBusiness _tipoProductoBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness, IProgresoProdep _progresoProdep, IDocumentosBusiness _documentosBusiness)
        {
            estadiaEmpresaBusiness = _estadiaEmpresaBusiness;
            tipoProductoBusiness = _tipoProductoBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            progresoProdep = _progresoProdep;
            documentosBusiness = _documentosBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoProducto = new SelectList(tipoProductoBusiness.GetAllTipoProducto(),"id","strDescripcion");
                ViewBag.idProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.strEstadoEstadia = new SelectList(list.FillEstadoEstadia());
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
            
        }

        [HttpPost]
        public ActionResult Create(EstadiaEmpresaVM estadiaEmpresaVM)
        {
            if (ModelState.IsValid)
            {
                EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();
                DocumentosDomainModel documentosDM = new DocumentosDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_ESTADIA_EMPRESA);

                estadiaEmpresaVM.idPersonal = idPersonal;
                estadiaEmpresaVM.idStatus = idStatus;

                AutoMapper.Mapper.Map(estadiaEmpresaVM,estadiaEmpresaDM);
                AutoMapper.Mapper.Map(estadiaEmpresaVM.documentosVM,documentosDM);
                estadiaEmpresaDM.documentosDM = documentosDM;

                if (GuadarArchivo(estadiaEmpresaDM,nombre))
                {
                    estadiaEmpresaDM.documentosDM.StrUrl = estadiaEmpresaDM.documentosDM.DocumentoFile.FileName;
                    DocumentosDomainModel documentos = documentosBusiness.AddDocumento(documentosDM);
                    estadiaEmpresaDM.idDocumento = documentos.IdDocumento;
                    estadiaEmpresaBusiness.AddUpdateEstadiaEmpresa(estadiaEmpresaDM);
                    progresoProdepDM.idPersonal = idPersonal;
                    progresoProdepDM.idStatus = idStatus;
                    progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
                }
            }

            return RedirectToAction("Create","EstadiaEmpresa");
        }

        public bool GuadarArchivo(EstadiaEmpresaDomainModel estadiaEmpresaDM, string nombre)
        {
            bool respuesta = false;

            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));

            if (Directory.Exists(path))
            {
                if (estadiaEmpresaDM.documentosDM.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pahtCompleto = Path.Combine(path, Path.GetFileName(estadiaEmpresaDM.documentosDM.DocumentoFile.FileName));
                    estadiaEmpresaDM.documentosDM.DocumentoFile.SaveAs(pahtCompleto);
                    respuesta = true;
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                GuadarArchivo(estadiaEmpresaDM, nombre);
                respuesta = true;
            }
            return respuesta;
        }
    }
}