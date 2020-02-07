using AppDigitalCv.Business.Interface;
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
    public class CapacitacionesRecibidasController : Controller
    {

        ITipoCapacitacionBusiness tipoCapacitacionBusiness;
        ICapacitacionesRecibidasBusiness capacitacionesRecibidasBusiness;
        IDocumentosBusiness documentosBusiness;
        public CapacitacionesRecibidasController(ITipoCapacitacionBusiness _tipoCapacitacionBusiness, ICapacitacionesRecibidasBusiness _capacitacionesRecibidasBusiness,IDocumentosBusiness _documentosBusiness)
        {
            tipoCapacitacionBusiness = _tipoCapacitacionBusiness;
            capacitacionesRecibidasBusiness = _capacitacionesRecibidasBusiness;
            documentosBusiness = _documentosBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoCapacitacion = new SelectList(tipoCapacitacionBusiness.GetTiposCapacitacion(), "id", "strValor");

                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
            
        }

        [HttpPost]
        public ActionResult Create(CapacitacionesRecibidasVM capacitacionesRecibidasVM)
        {

            if (ModelState.IsValid)
            {
                Object[] obj = CrearDocumentoPersonales(capacitacionesRecibidasVM);

                if (obj[0].Equals(true))
                {
                    CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel = new CapacitacionesRecibidasDomainModel();
                    AutoMapper.Mapper.Map(capacitacionesRecibidasVM,capacitacionesRecibidasDomainModel);
                    capacitacionesRecibidasDomainModel.Documentos.StrUrl = obj[1].ToString();
                    capacitacionesRecibidasBusiness.AddCapacitacion(capacitacionesRecibidasDomainModel);
                }
            }

            return RedirectToAction("Create", "CapacitacionesRecibidas");
        }

        public Object[] CrearDocumentoPersonales(CapacitacionesRecibidasVM capacitacionesRecibidasVM)
        {
            Object[] respuesta = new Object[2];
            capacitacionesRecibidasVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (capacitacionesRecibidasVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, capacitacionesRecibidasVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(capacitacionesRecibidasVM);
            }

            return respuesta;
        }
        [HttpGet]
        public JsonResult GetCapacitacionesRecibidas(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CapacitacionesRecibidasDomainModel> capacitacionesRecibidasDomainModels = new List<CapacitacionesRecibidasDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                capacitacionesRecibidasDomainModels = capacitacionesRecibidasBusiness.GetCapacitacionesRecibidas(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = capacitacionesRecibidasBusiness.GetCapacitacionesRecibidas(identityPersonal).Count();

                capacitacionesRecibidasDomainModels = capacitacionesRecibidasBusiness.GetCapacitacionesRecibidas(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = capacitacionesRecibidasDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = capacitacionesRecibidasDomainModels.Count(),
                iTotalRecords = capacitacionesRecibidasDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCapacitacionDelete(int _id)
        {
            if (_id > 0)
            {
                CapacitacionesRecibidasVM capacitacionesRecibidasVM = new CapacitacionesRecibidasVM();

                CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel = new CapacitacionesRecibidasDomainModel();

                capacitacionesRecibidasDomainModel = capacitacionesRecibidasBusiness.GetCapacitacionRecibida(_id);

                AutoMapper.Mapper.Map(capacitacionesRecibidasDomainModel, capacitacionesRecibidasVM);

                return PartialView("_Eliminar", capacitacionesRecibidasVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeleteCapacitacionRecibida(CapacitacionesRecibidasVM capacitacionesRecibidasVM)
        {
            if (capacitacionesRecibidasVM.id > 0)
            {
                CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel = new CapacitacionesRecibidasDomainModel();

                capacitacionesRecibidasDomainModel = capacitacionesRecibidasBusiness.GetCapacitacionRecibida(capacitacionesRecibidasVM.id);

                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + capacitacionesRecibidasDomainModel.Documentos.StrUrl);

                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(capacitacionesRecibidasDomainModel.idDocumento);
                }           
            }
            return RedirectToAction("Create","CapacitacionesRecibidas");
        }
    }
}