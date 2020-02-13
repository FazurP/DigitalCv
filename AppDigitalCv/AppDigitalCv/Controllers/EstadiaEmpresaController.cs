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
        IDocumentosBusiness documentosBusiness;
        List list = new List();

        public EstadiaEmpresaController(IEstadiaEmpresaBusiness _estadiaEmpresaBusiness,ITipoProductoBusiness _tipoProductoBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness, IDocumentosBusiness _documentosBusiness)
        {
            estadiaEmpresaBusiness = _estadiaEmpresaBusiness;
            tipoProductoBusiness = _tipoProductoBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            documentosBusiness = _documentosBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
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

                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                estadiaEmpresaVM.idPersonal = idPersonal;

                AutoMapper.Mapper.Map(estadiaEmpresaVM,estadiaEmpresaDM);

                object[] obj = CrearDocumentoPersonales(estadiaEmpresaVM);

                if (obj[0].Equals(true))
                {
                    estadiaEmpresaDM.documentos = new DocumentosDomainModel { StrUrl = obj[1].ToString() };
                    estadiaEmpresaBusiness.AddUpdateEstadiaEmpresa(estadiaEmpresaDM);
                }
            }
            return RedirectToAction("Create","EstadiaEmpresa");
        }

        private Object[] CrearDocumentoPersonales(EstadiaEmpresaVM estadiaEmpresaVM)
        {
            Object[] respuesta = new Object[2];
            estadiaEmpresaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (estadiaEmpresaVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, estadiaEmpresaVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(estadiaEmpresaVM);
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
                estadiasDM = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).Where(p => p.strNombreEmpresaInstitucion.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).Count();

                estadiasDM = estadiaEmpresaBusiness.GetAllEstadiaEmpresaByIdPersonal(identityPersonal).OrderBy(p => p.strNombreEmpresaInstitucion).Skip((pageNo - 1)
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
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + estadiaEmpresaDM.documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(estadiaEmpresaDM.idDocumento);
                }
                  
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
                ViewBag.strEstadoEstadia = new SelectList(list.FillEstadoEstadia());
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