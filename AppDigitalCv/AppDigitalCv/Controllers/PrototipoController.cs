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
    public class PrototipoController : Controller
    {
        IPaisBusiness paisBusiness;
        IUnitOfWork unitofWork;
        IDocumentosBusiness documentosBusiness;
        IPrototipoBusiness prototipoBusiness;
        List list = new List();

        public PrototipoController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IDocumentosBusiness _documentosBusiness,
            IPrototipoBusiness _prototipoBusiness)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            documentosBusiness = _documentosBusiness;
            prototipoBusiness = _prototipoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoPrototipo = new SelectList(list.FillTipoPrototipo());
                ViewBag.strEstadoActual = new SelectList(list.FillEstado());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                ViewBag.strProposito = new SelectList(list.FillProposito());

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
            }

        }

        [HttpPost]
        public ActionResult Create(PrototipoVM prototipoVM)
        {
            if (ModelState.IsValid)
            {
                PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                prototipoVM.idPersonal = idPersonal;

                AutoMapper.Mapper.Map(prototipoVM,prototipoDM);

                object[] obj = CrearDocumentoPersonales(prototipoVM);

                if (obj[0].Equals(true))
                {
                    prototipoDM.documentos = new DocumentosDomainModel { StrUrl=obj[1].ToString() };
                    prototipoBusiness.AddUpdatePrototipo(prototipoDM);
                }

            }

            return RedirectToAction("Create","Prototipo");
        }

        private Object[] CrearDocumentoPersonales(PrototipoVM prototipoVM)
        {
            Object[] respuesta = new Object[2];
            prototipoVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (prototipoVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, prototipoVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(prototipoVM);
            }

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetPrototipos(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<PrototipoDomainModel> prototipos = new List<PrototipoDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                prototipos = prototipoBusiness.GetPrototipos(IdentityPersonal).Where(p => p.strNombrePrototipo.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = prototipoBusiness.GetPrototipos(IdentityPersonal).Count();


                prototipos = prototipoBusiness.GetPrototipos(IdentityPersonal).OrderBy(p => p.strNombrePrototipo)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = prototipos,
                sEcho = param.sEcho,
                iTotalDisplayRecords = prototipos.Count(),
                iTotalRecords = prototipos.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPrototipoDelete(int _idPrototipo)
        {
            PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

            prototipoDM = prototipoBusiness.GetPrototipoById(_idPrototipo);

            if (prototipoDM != null)
            {
                PrototipoVM prototipoVM = new PrototipoVM();

                AutoMapper.Mapper.Map(prototipoDM,prototipoVM);

                return PartialView("_Eliminar",prototipoVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeletePrototipo(PrototipoVM prototipoVM)
        {
            PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

            prototipoDM = prototipoBusiness.GetPrototipoById(prototipoVM.id);

            if (prototipoDM != null)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + prototipoDM.documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(prototipoDM.idDocumento);
                }            
            }

            return RedirectToAction("Create","Prototipo");
        }

        [HttpGet]
        public ActionResult GetPropositoUpdate(int _idPrototipo)
        {
            PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

            prototipoDM = prototipoBusiness.GetPrototipoById(_idPrototipo);

            if (prototipoDM != null)
            {
                PrototipoVM prototipoVM = new PrototipoVM();

                AutoMapper.Mapper.Map(prototipoDM, prototipoVM);

                return PartialView("_Editar", prototipoVM);
            }

            return PartialView("_Editar");
        }

        [HttpPost]
        public ActionResult UpdatePrototipo(PrototipoVM prototipoVM)
        {
            PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

            if (prototipoVM.id > 0)
            {
                AutoMapper.Mapper.Map(prototipoVM,prototipoDM);

                prototipoBusiness.AddUpdatePrototipo(prototipoDM);
            }

            return RedirectToAction("Create","Prototipo");
        }

    }
}