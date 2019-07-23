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

        [HttpGet]
        public JsonResult GetEstadias(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<EstadiaEmpresaDomainModel> estadiasDM = new List<EstadiaEmpresaDomainModel>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                estadiasDM = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).Where(p => p.strNombreEstadia.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).Count();

                estadiasDM = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).OrderBy(p => p.strNombreEstadia).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {

                aaData = estadiasDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = estadiasDM.Count(),
                iTotalRecords = estadiasDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEstadiaDelete(int _idEstadia)
        {
            EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();
            EstadiaEmpresaVM estadiaEmpresaVM = new EstadiaEmpresaVM();

            estadiaEmpresaDM = estadiaEmpresaBusiness.GetEstadiaEmpresaById(_idEstadia);

            if (estadiaEmpresaDM != null)
            {
                AutoMapper.Mapper.Map(estadiaEmpresaDM,estadiaEmpresaVM);
                return PartialView("_Eliminar",estadiaEmpresaVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteEstadia(EstadiaEmpresaVM estadiaEmpresaVM)
        {
            EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();

            estadiaEmpresaDM = estadiaEmpresaBusiness.GetEstadiaEmpresaById(estadiaEmpresaVM.id);

            if (estadiaEmpresaDM != null)
            {
                if (progresoProdep.GetProgresoByPersonal(SessionPersister.AccountSession.IdPersonal).Count == 1)
                {
                    documentosBusiness.DeleteDocumento(estadiaEmpresaDM.idDocumento);
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal,int.Parse(Recursos.RecursosSistema.REGISTRO_ESTADIA_EMPRESA));
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                }
                    documentosBusiness.DeleteDocumento(estadiaEmpresaDM.idDocumento);
            }

            return RedirectToAction("Create","EstadiaEmpresa");
        }

        [HttpGet]
        public ActionResult GetEstadiaUpdate(int _idEstadia)
        {
            EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();
            EstadiaEmpresaVM empresaVM = new EstadiaEmpresaVM();

            estadiaEmpresaDM = estadiaEmpresaBusiness.GetEstadiaEmpresaById(_idEstadia);

            if (estadiaEmpresaDM != null)
            {
                AutoMapper.Mapper.Map(estadiaEmpresaDM,empresaVM);
                return PartialView("_Editar",empresaVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateEstadia(EstadiaEmpresaVM estadiaEmpresaVM)
        {

            EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();

            if (estadiaEmpresaVM.id > 0)
            {
                AutoMapper.Mapper.Map(estadiaEmpresaVM,estadiaEmpresaDM);

                estadiaEmpresaBusiness.AddUpdateEstadiaEmpresa(estadiaEmpresaDM);
            }

            return RedirectToAction("Create","EstadiaEmpresa");
        }
    }
}