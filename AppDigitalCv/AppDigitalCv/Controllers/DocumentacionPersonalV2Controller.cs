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
    public class DocumentacionPersonalV2Controller : Controller
    {
        List documentos = new List();

        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;
        IDocumentacionPersonalV2Business IdocumentacionPersonalBusiness;
        ITipoDocumentoBusiness tipoDocumentoBusiness;
        public DocumentacionPersonalV2Controller(IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness
            , IDocumentacionPersonalV2Business _IdocumentacionPersonalBusiness,ITipoDocumentoBusiness _tipoDocumentoBusiness)
        {
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
            IdocumentacionPersonalBusiness = _IdocumentacionPersonalBusiness;
            tipoDocumentoBusiness = _tipoDocumentoBusiness;
        }
        /// <summary>
        /// Este metodo se encarga de cargar la pantalla principal
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoDocumento = new SelectList(tipoDocumentoBusiness.GetAllTiposDocumentoPendientes(SessionPersister.AccountSession.IdPersonal),"id","strValor");
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
       
        }
        /// <summary>
        /// Este metodo se encarga de recibir la informacion y validarla
        /// </summary>
        /// <param name="documentacionPersonalVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult Create(DocumentacionPersonalV2VM documentacionPersonalVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Object[] obj = CrearDocumentoPersonales(documentacionPersonalVM);

                    if (obj[0].Equals(true))
                    {                     
                        DocumentacionPersonalV2DomainModel documentacionPersonalV2DomainModel = new DocumentacionPersonalV2DomainModel();
                        AutoMapper.Mapper.Map(documentacionPersonalVM, documentacionPersonalV2DomainModel);
                        documentacionPersonalV2DomainModel.Documentos = new DocumentosDomainModel { StrUrl = obj[1].ToString() };

                        IdocumentacionPersonalBusiness.AddDocumentacionPersonal(documentacionPersonalV2DomainModel);
                    }
                   
                }
                return RedirectToAction("Create", "DocumentacionPersonalV2");
            }
            catch (Exception ex)
            {

                string me = ex.Message;
                return RedirectToAction("Create", "DocumentacionPersonalV2");
            }
         

        }
        /// <summary>
        /// Este metodo se encarga de guardar los documentos en el servidor
        /// </summary>
        /// <param name="documentacionPersonalVM"></param>
        public Object[] CrearDocumentoPersonales(DocumentacionPersonalV2VM documentacionPersonalVM)
        {
            Object[] respuesta = new Object[2];
            documentacionPersonalVM.idPesonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (documentacionPersonalVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, documentacionPersonalVM.Documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(documentacionPersonalVM);          
            }

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetDocumentos(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DocumentosDomainModel> documentosDM = new List<DocumentosDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                documentosDM = IdocumentosBusiness.GetDocumetosByIdPersonal(IdentityPersonal).Where(p => p.StrUrl.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = IdocumentosBusiness.GetDocumetosByIdPersonal(IdentityPersonal).Count();


                documentosDM = IdocumentosBusiness.GetDocumetosByIdPersonal(IdentityPersonal).OrderBy(p => p.StrUrl)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = documentosDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = documentosDM.Count(),
                iTotalRecords = documentosDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetDocumentoDelete(int IdDocumento) 
        {
            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();

            documentosDomainModel = IdocumentosBusiness.GetDocumentoByIdDocumento(IdDocumento);

            DocumentosVM documentosVM = new DocumentosVM();

            AutoMapper.Mapper.Map(documentosDomainModel, documentosVM);

            return PartialView("_Eliminar", documentosVM);
        }

        public ActionResult DeleteDocumento(DocumentosDomainModel documentosDomainModel) 
        {
            if (documentosDomainModel.IdDocumento > 0)
            {
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto +"/"+ documentosDomainModel.StrUrl);

                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    IdocumentosBusiness.DeleteDocumento(documentosDomainModel.IdDocumento);
                }
            }

            return RedirectToAction("Create","DocumentacionPersonalV2");
        }
    }
}