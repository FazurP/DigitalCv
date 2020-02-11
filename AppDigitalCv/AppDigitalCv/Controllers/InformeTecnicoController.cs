using AppDigitalCv.Business.Enum;
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
    public class InformeTecnicoController : Controller
    {
        List list = new List();
        IPaisBusiness paisBusiness;
        IDocumentosBusiness documentosBusiness;
        IInformeTecnicoBusiness informeTecnicoBusiness;

        public InformeTecnicoController(IPaisBusiness _paisBusiness, IDocumentosBusiness _documentosBusiness,IInformeTecnicoBusiness
            _informeTecnicoBusiness) {
            paisBusiness = _paisBusiness;
            documentosBusiness = _documentosBusiness;
            informeTecnicoBusiness = _informeTecnicoBusiness;

        }

        [HttpGet]
        public ActionResult Create() {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.enumEstadoActual = new SelectList(list.FillEstado());
                ViewBag.enumProposito = new SelectList(list.FillProposito());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                return View();
            }
            return RedirectToAction("Login", "Seguridad");
        }

        [HttpPost]
        public ActionResult Create(InformeTecnicoVM informeTecnicoVM) {

            string nombre = SessionPersister.AccountSession.NombreCompleto;
            informeTecnicoVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

            if (ModelState.IsValid)
            {
                InformeTecnicoDomainModel informeTecnicoDM = new InformeTecnicoDomainModel();

                AutoMapper.Mapper.Map(informeTecnicoVM,informeTecnicoDM);

                object[] obj = CrearDocumentoPersonales(informeTecnicoVM);

                if (obj[0].Equals(true))
                {
                    informeTecnicoDM.Documentos = new DocumentosDomainModel { StrUrl = obj[1].ToString() };
                    informeTecnicoBusiness.AddUpdateInformeTecnico(informeTecnicoDM);                                    
                }

            }

            return RedirectToAction("Create","InformeTecnico");
        }

        public Object[] CrearDocumentoPersonales(InformeTecnicoVM informeTecnicoVM)
        {
            Object[] respuesta = new Object[2];
            informeTecnicoVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (informeTecnicoVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, informeTecnicoVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(informeTecnicoVM);
            }
            return respuesta;
        }

        [HttpGet]
        public JsonResult GetInformesTecnicos(DataTablesParam param)
        {

            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<InformeTecnicoDomainModel> informeDM = new List<InformeTecnicoDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                informeDM = informeTecnicoBusiness.GetInformesByUsuario(IdentityPersonal).Where(p => p.strAutor.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = informeTecnicoBusiness.GetInformesByUsuario(IdentityPersonal).Count();


                informeDM = informeTecnicoBusiness.GetInformesByUsuario(IdentityPersonal).OrderBy(p => p.strAutor)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = informeDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = informeDM.Count(),
                iTotalRecords = informeDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetInformeTecnicoDelete(int _idInformeTecnico) {

            InformeTecnicoVM informeTecnicoVM = new InformeTecnicoVM();
            InformeTecnicoDomainModel informeTecnicoDM = informeTecnicoBusiness.GetInformeTecnico(_idInformeTecnico);

            if (informeTecnicoDM != null)
            {
                AutoMapper.Mapper.Map(informeTecnicoDM,informeTecnicoVM);

            }

            return PartialView("_Eliminar", informeTecnicoVM);
        }

        [HttpPost]
        public ActionResult DeleteInformeTecnico(InformeTecnicoVM informeTecnicoVM) {

            InformeTecnicoDomainModel informeTecnicoDM = new InformeTecnicoDomainModel();
            informeTecnicoDM = informeTecnicoBusiness.GetInformeTecnico(informeTecnicoVM.id);

            if (informeTecnicoDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + informeTecnicoDM.Documentos.StrUrl);

                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(informeTecnicoDM.idDocumento);
                }
                          
            }

            return RedirectToAction("Create","InformeTecnico");
        }

        [HttpGet]
        public ActionResult GetInformeTecnicoUpdate(int _idInformeTecnico) {

            InformeTecnicoVM informeTecnicoVM = new InformeTecnicoVM();
            InformeTecnicoDomainModel informeTecnicoDM = informeTecnicoBusiness.GetInformeTecnico(_idInformeTecnico);

            if (informeTecnicoDM != null)
            {
                AutoMapper.Mapper.Map(informeTecnicoDM, informeTecnicoVM);

            }

            return PartialView("_Editar", informeTecnicoVM);
        }

        [HttpPost]
        public ActionResult UpdateInformeTecnico(InformeTecnicoVM informeTecnicoVM) {

            InformeTecnicoDomainModel informeTecnicoDM = new InformeTecnicoDomainModel();

            if (informeTecnicoVM.id > 0)
            {
                AutoMapper.Mapper.Map(informeTecnicoVM,informeTecnicoDM);
                informeTecnicoBusiness.AddUpdateInformeTecnico(informeTecnicoDM);
            }
            return RedirectToAction("Create", "InformeTecnico");
        }
    }
}