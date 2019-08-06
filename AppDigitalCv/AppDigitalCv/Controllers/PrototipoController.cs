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
        IProgresoProdep progresoProdep;
        List list = new List();

        public PrototipoController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IDocumentosBusiness _documentosBusiness,
            IPrototipoBusiness _prototipoBusiness, IProgresoProdep _progresoProdep)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            documentosBusiness = _documentosBusiness;
            prototipoBusiness = _prototipoBusiness;
            progresoProdep = _progresoProdep;
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
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();
                DocumentosDomainModel documentosDM = new DocumentosDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_PROTOTIPO);

                prototipoVM.idPersonal = idPersonal;
                prototipoVM.idStatsu = idStatus;

                AutoMapper.Mapper.Map(prototipoVM,prototipoDM);
                AutoMapper.Mapper.Map(prototipoVM.documentosVM, documentosDM);
                prototipoDM.documentosDM = documentosDM;

                if (GuadarArchivo(prototipoDM,nombre))
                {
                    prototipoDM.documentosDM.StrUrl = prototipoDM.documentosDM.DocumentoFile.FileName;
                    DocumentosDomainModel documento = documentosBusiness.AddDocumento(documentosDM);
                    prototipoDM.idDocumento = documento.IdDocumento;
                    prototipoBusiness.AddUpdatePrototipo(prototipoDM);
                    progresoProdepDM.idPersonal = idPersonal;
                    progresoProdepDM.idStatus = idStatus;
                    progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
                }

            }

            return RedirectToAction("Create","Prototipo");
        }

        public bool GuadarArchivo(PrototipoDomainModel prototipoDomainModel, string nombre)
        {
            bool respuesta = false;

            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));

            if (Directory.Exists(path))
            {
                if (prototipoDomainModel.documentosDM.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pahtCompleto = Path.Combine(path, Path.GetFileName(prototipoDomainModel.documentosDM.DocumentoFile.FileName));
                    prototipoDomainModel.documentosDM.DocumentoFile.SaveAs(pahtCompleto);
                    respuesta = true;
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                GuadarArchivo(prototipoDomainModel, nombre);
                respuesta = true;
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
                if (prototipoBusiness.GetPrototipos(SessionPersister.AccountSession.IdPersonal).Count == 1)
                {
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal, int.Parse(Recursos.RecursosSistema.REGISTRO_PROTOTIPO));
                    documentosBusiness.DeleteDocumento(prototipoDM.idDocumento);
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                }
                else
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