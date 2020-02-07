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
    public class CapacitacionesImpartidasController : Controller
    {
        ITipoCapacitacionBusiness tipoCapacitacionBusiness;
        ICapacitacionesImpartidasBusiness capacitacionesImpartidasBusiness;
        IDocumentosBusiness documentosBusiness;

        public CapacitacionesImpartidasController(ITipoCapacitacionBusiness _tipoCapacitacionBusiness, ICapacitacionesImpartidasBusiness _capacitacionesImpartidasBusiness,IDocumentosBusiness _documentosBusiness)
        {
            tipoCapacitacionBusiness = _tipoCapacitacionBusiness;
            capacitacionesImpartidasBusiness = _capacitacionesImpartidasBusiness;
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
        public ActionResult Create(CapacitacionesImpartidadVM capacitacionesImpartidadVM)
        {
            if (ModelState.IsValid)
            {
                object[] obj = CrearDocumentoPersonales(capacitacionesImpartidadVM);

                if (obj[0].Equals(true))
                {
                    CapacitacionesImpartidadDomainModel capacitacionesImpartidadDomainModel = new CapacitacionesImpartidadDomainModel();
                    AutoMapper.Mapper.Map(capacitacionesImpartidadVM, capacitacionesImpartidadDomainModel);
                    capacitacionesImpartidadDomainModel.Documentos.StrUrl = obj[1].ToString();
                    capacitacionesImpartidasBusiness.AddCapacitacion(capacitacionesImpartidadDomainModel);
                }
            }
            return RedirectToAction("Create", "CapacitacionesImpartidas");
        }

        private Object[] CrearDocumentoPersonales(CapacitacionesImpartidadVM capacitacionesImpartidadVM)
        {
            Object[] respuesta = new Object[2];
            capacitacionesImpartidadVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (capacitacionesImpartidadVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, capacitacionesImpartidadVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(capacitacionesImpartidadVM);
            }

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetCapacitacionesImpartidas(DataTablesParam param)
        {

            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CapacitacionesImpartidadDomainModel> capacitacionesImpartidasDomainModels = new List<CapacitacionesImpartidadDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                capacitacionesImpartidasDomainModels = capacitacionesImpartidasBusiness.GetCapacitacionesImpartidas(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = capacitacionesImpartidasBusiness.GetCapacitacionesImpartidas(identityPersonal).Count();

                capacitacionesImpartidasDomainModels = capacitacionesImpartidasBusiness.GetCapacitacionesImpartidas(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = capacitacionesImpartidasDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = capacitacionesImpartidasDomainModels.Count(),
                iTotalRecords = capacitacionesImpartidasDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetCapacitacionDelete(int _id)
        {
            if (_id > 0)
            {
                CapacitacionesImpartidadVM capacitacionesImpartidaVM = new CapacitacionesImpartidadVM();

                CapacitacionesImpartidadDomainModel capacitacionesImpartidasDomainModel = new CapacitacionesImpartidadDomainModel();

                capacitacionesImpartidasDomainModel = capacitacionesImpartidasBusiness.GetCapacitacionImpartida(_id);

                AutoMapper.Mapper.Map(capacitacionesImpartidasDomainModel, capacitacionesImpartidaVM);

                return PartialView("_Eliminar", capacitacionesImpartidaVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeleteCapacitacionImpartida(CapacitacionesImpartidadVM capacitacionesImpartidadVM)
        {
            if (capacitacionesImpartidadVM.id > 0)
            {
                CapacitacionesImpartidadDomainModel capacitacionesImpartidaDomainModel = new CapacitacionesImpartidadDomainModel();

                capacitacionesImpartidaDomainModel = capacitacionesImpartidasBusiness.GetCapacitacionImpartida(capacitacionesImpartidadVM.id);

                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + capacitacionesImpartidaDomainModel.Documentos.StrUrl);

                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(capacitacionesImpartidaDomainModel.idDocumento);
                }
            }
            return RedirectToAction("Create", "CapacitacionesImpartidas");
        }
    }
}