using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
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
        public DocumentacionPersonalV2Controller(IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness
            , IDocumentacionPersonalV2Business _IdocumentacionPersonalBusiness)
        {
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
            IdocumentacionPersonalBusiness = _IdocumentacionPersonalBusiness;
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
                ViewBag.strIdentificador = new SelectList(documentos.fillDocuments());
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
                    this.CrearDocumentoPersonales(documentacionPersonalVM);
                   
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
        public void CrearDocumentoPersonales(DocumentacionPersonalV2VM documentacionPersonalVM)
        {
            
            documentacionPersonalVM.idPesonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);

                if (documentacionPersonalVM.DocumentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpath = documentacionPersonalVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.DocumentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    documentacionPersonalVM.DocumentosVM = documentoVM;
                }


                this.AddEditDocumentosPersonales(documentacionPersonalVM);
            }
            else
            {
                if (documentacionPersonalVM.DocumentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpath = documentacionPersonalVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.DocumentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    documentacionPersonalVM.DocumentosVM = documentoVM;
                }

                this.AddEditDocumentosPersonales(documentacionPersonalVM);
            }
        }
        /// <summary>
        /// Este metodo se encarga insertar el objeto en la base de datos.
        /// </summary>
        /// <param name="documentacionPersonalVM"></param>
        /// <returns>true o false</returns>
        public bool AddEditDocumentosPersonales(DocumentacionPersonalV2VM documentacionPersonalVM)
        {
            bool resultado = false;
            DocumentacionPersonalV2DomainModel documentacionPersonalDM = new DocumentacionPersonalV2DomainModel();
            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();
            AutoMapper.Mapper.Map(documentacionPersonalVM, documentacionPersonalDM);///hacemos el mapeado de la entidad
            AutoMapper.Mapper.Map(documentacionPersonalVM.DocumentosVM, documentosDomainModel);
            documentacionPersonalDM.DocumentosDomainModel = documentosDomainModel;

            DocumentosDomainModel documento = IdocumentosBusiness.AddDocumento(documentosDomainModel);
            documentacionPersonalDM.idDocumento = documento.IdDocumento;
            resultado = IdocumentacionPersonalBusiness.AddDocumentacionPersonal(documentacionPersonalDM);
            return resultado;
        }
    }
}