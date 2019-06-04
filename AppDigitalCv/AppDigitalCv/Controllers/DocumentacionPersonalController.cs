using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Repository;
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
    public class DocumentacionPersonalController : Controller
    {

        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;
        IDocumentacionPersonalBusiness IdocumentacionPersonalBusiness;
        public DocumentacionPersonalController(IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness
            ,IDocumentacionPersonalBusiness _IdocumentacionPersonalBusiness)
        {
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
            IdocumentacionPersonalBusiness = _IdocumentacionPersonalBusiness;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
            }
        }

        [HttpPost]
        public ActionResult Create(DocumentacionPersonalVM documentacionPersonalVM)
        {          
            documentacionPersonalVM.NumeroCartillaMilitarVM.strIdentificador = "Cartilla Militar";
            documentacionPersonalVM.NumeroLicenciaManejoVM.strIdentificador = "Licencia de Manejo";
            documentacionPersonalVM.NumeroPasaporteVM.strIdentificador = "Pasaporte";
            documentacionPersonalVM.NumeroSeguridadSocialVM.strIdentificador = "Seguridad Social";
            documentacionPersonalVM.NumeroVisaCanadaVM.strIdentificador = "Visa de Canada";
            documentacionPersonalVM.NumeroVisaUsaVM.strIdentificador = "Visa de USA";
            documentacionPersonalVM.RegistroProfEstatalVM.strIdentificador = "Registro Estatal";
            documentacionPersonalVM.IfeVM.strIdentificador = "IFE";
            documentacionPersonalVM.ComprobanteDomicilioVM.strIdentificador = "Comprobante Domicilio";
            documentacionPersonalVM.SolicitudEmpleoVM.strIdentificador = "Solicitud Empleo";

            if (ModelState.IsValid || documentacionPersonalVM != null)
            {
                this.CrearDocumentoPersonales(documentacionPersonalVM);
                return RedirectToAction("Create", "DocumentacionPersonal");
            } 
            else {
                return RedirectToAction("Create", "DocumentacionPersonal");
            }

        }

        public void CrearDocumentoPersonales(DocumentacionPersonalVM documentacionPersonalVM)
        {
            //PersonalDomainModel personalDM = this.GetPersonalVM(documentacionPersonalVM.idPersonal);
            //documentacionPersonalVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));
            string pathCartilla = "";
            string pathPasaporte = "";
            string pathSeguridadSocial = "";
            string pathVisaCanada = "";
            string pathVisaUsa = "";
            string pathRegistroEstatal = "";
            string pathIfe = "";
            string pathComprobante = "";
            string pathSolicitud = "";

            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);

                if (documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpath = documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM = documentoVM;
                }
                if (documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile != null)
                {
                    pathCartilla = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathCartilla = documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.SaveAs(pathCartilla);
                    DocumentosVM documentoVMCartilla = new DocumentosVM();
                    documentoVMCartilla.StrUrl = sfpathCartilla;
                    documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM = documentoVMCartilla;
                }
                if (documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile != null)
                {
                    pathPasaporte = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathPasaporte = documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.SaveAs(pathPasaporte);
                    DocumentosVM documentoVMPasaporte = new DocumentosVM();
                    documentoVMPasaporte.StrUrl = sfpathPasaporte;
                    documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM = documentoVMPasaporte;
                }
                if (documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile != null)
                {
                    pathSeguridadSocial = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathSeguridadSocail = documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.SaveAs(pathSeguridadSocial);
                    DocumentosVM documentoVMSeguridadSocial = new DocumentosVM();
                    documentoVMSeguridadSocial.StrUrl = sfpathSeguridadSocail;
                    documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM = documentoVMSeguridadSocial;
                }
                if (documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile != null)
                {
                    pathVisaCanada = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathVisaCanada = documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.SaveAs(pathVisaCanada);
                    DocumentosVM documentoVMVisaCanada = new DocumentosVM();
                    documentoVMVisaCanada.StrUrl = sfpathVisaCanada;
                    documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM = documentoVMVisaCanada;
                }
                if (documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile != null)
                {
                    pathVisaUsa = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathVisaUsa = documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.SaveAs(pathVisaUsa);
                    DocumentosVM documentoVMVisaUsa = new DocumentosVM();
                    documentoVMVisaUsa.StrUrl = sfpathVisaUsa;
                    documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM = documentoVMVisaUsa;
                }
                if (documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile != null)
                {
                    pathRegistroEstatal = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathRegistroEstatal = documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.SaveAs(pathRegistroEstatal);
                    DocumentosVM documentoVMRegistroEstatal = new DocumentosVM();
                    documentoVMRegistroEstatal.StrUrl = sfpathRegistroEstatal;
                    documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM = documentoVMRegistroEstatal;
                }
                if (documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile != null)
                {
                    pathIfe = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathIfe = documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.SaveAs(pathIfe);
                    DocumentosVM documentoVMIfe = new DocumentosVM();
                    documentoVMIfe.StrUrl = sfpathIfe;
                    documentacionPersonalVM.IfeVM.DocumentosVM = documentoVMIfe;
                }
                if (documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile != null)
                {
                    pathComprobante = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathComprobante = documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.SaveAs(pathComprobante);
                    DocumentosVM documentoVMComprobante = new DocumentosVM();
                    documentoVMComprobante.StrUrl = sfpathComprobante;
                    documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM = documentoVMComprobante;
                }
                if (documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile != null)
                {
                    pathSolicitud = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathSolicitud = documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.SaveAs(pathSolicitud);
                    DocumentosVM documentoVMSolicitud = new DocumentosVM();
                    documentoVMSolicitud.StrUrl = sfpathSolicitud;
                    documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM = documentoVMSolicitud;
                }
                
                this.AddEditDocumentosPersonales(documentacionPersonalVM);
            }
            else
            {
                if (documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile != null)
                {
                    path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpath = documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.SaveAs(path);
                    DocumentosVM documentoVM = new DocumentosVM();
                    documentoVM.StrUrl = sfpath;
                    documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM = documentoVM;
                }
                if (documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile != null)
                {
                    pathCartilla = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathCartilla = documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.SaveAs(pathCartilla);
                    DocumentosVM documentoVMCartilla = new DocumentosVM();
                    documentoVMCartilla.StrUrl = sfpathCartilla;
                    documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM = documentoVMCartilla;
                }
                if (documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile != null)
                {
                    pathPasaporte = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathPasaporte = documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.SaveAs(pathPasaporte);
                    DocumentosVM documentoVMPasaporte = new DocumentosVM();
                    documentoVMPasaporte.StrUrl = sfpathPasaporte;
                    documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM = documentoVMPasaporte;
                }
                if (documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile != null)
                {
                    pathSeguridadSocial = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathSeguridadSocail = documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.SaveAs(pathSeguridadSocial);
                    DocumentosVM documentoVMSeguridadSocial = new DocumentosVM();
                    documentoVMSeguridadSocial.StrUrl = sfpathSeguridadSocail;
                    documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM = documentoVMSeguridadSocial;
                }
                if (documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile != null)
                {
                    pathVisaCanada = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathVisaCanada = documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.SaveAs(pathVisaCanada);
                    DocumentosVM documentoVMVisaCanada = new DocumentosVM();
                    documentoVMVisaCanada.StrUrl = sfpathVisaCanada;
                    documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM = documentoVMVisaCanada;
                }
                if (documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile != null)
                {
                    pathVisaUsa = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathVisaUsa = documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.SaveAs(pathVisaUsa);
                    DocumentosVM documentoVMVisaUsa = new DocumentosVM();
                    documentoVMVisaUsa.StrUrl = sfpathVisaUsa;
                    documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM = documentoVMVisaUsa;
                }
                if (documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile != null)
                {
                    pathRegistroEstatal = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathRegistroEstatal = documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.SaveAs(pathRegistroEstatal);
                    DocumentosVM documentoVMRegistroEstatal = new DocumentosVM();
                    documentoVMRegistroEstatal.StrUrl = sfpathRegistroEstatal;
                    documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM = documentoVMRegistroEstatal;
                }
                if (documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile != null)
                {
                    pathIfe = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathIfe = documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.SaveAs(pathIfe);
                    DocumentosVM documentoVMIfe = new DocumentosVM();
                    documentoVMIfe.StrUrl = sfpathIfe;
                    documentacionPersonalVM.IfeVM.DocumentosVM = documentoVMIfe;
                }
                if (documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile != null)
                {
                    pathComprobante = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathComprobante = documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.SaveAs(pathComprobante);
                    DocumentosVM documentoVMComprobante = new DocumentosVM();
                    documentoVMComprobante.StrUrl = sfpathComprobante;
                    documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM = documentoVMComprobante;
                }
                if (documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile != null)
                {
                    pathSolicitud = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName));
                    string sfpathSolicitud = documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName;
                    documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.SaveAs(pathSolicitud);
                    DocumentosVM documentoVMSolicitud = new DocumentosVM();
                    documentoVMSolicitud.StrUrl = sfpathSolicitud;
                    documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM = documentoVMSolicitud;
                }

                this.AddEditDocumentosPersonales(documentacionPersonalVM);
            }
        }

        public bool AddEditDocumentosPersonales(DocumentacionPersonalVM documentacionPersonalVM)
        {
            bool resultado = false;

            DocumentacionPersonalDomainModel documentacionPersonalDomainModel = new DocumentacionPersonalDomainModel();
            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();
            List<DocumentacionPersonalDomainModel> documentacion = new List<DocumentacionPersonalDomainModel>();
            List<DocumentosDomainModel> documentos = new List<DocumentosDomainModel>();

            if (documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo de la Licencia
                NumeroLicenciaManejoVM numeroLicenciaManejoVM = documentacionPersonalVM.NumeroLicenciaManejoVM;
                NumeroLicenciaManejoDomainModel numeroLicenciaManejoDM = new NumeroLicenciaManejoDomainModel();
                DocumentosVM documentosVM = numeroLicenciaManejoVM.DocumentosVM;
                DocumentosDomainModel documentosDM = new DocumentosDomainModel();

                //Mappeo de la Licencia
                AutoMapper.Mapper.Map(numeroLicenciaManejoVM, numeroLicenciaManejoDM);//Aqui
                AutoMapper.Mapper.Map(documentosVM, documentosDM);//Aqui

                DocumentacionPersonalDomainModel DocumentLicencia = new DocumentacionPersonalDomainModel();
                DocumentLicencia.NumeroLicenciaManejoDM = numeroLicenciaManejoDM;
                DocumentLicencia.strIdentificador = numeroLicenciaManejoDM.strIdentificador;
                DocumentLicencia.strNumeroDocumento = numeroLicenciaManejoDM.strNumeroDocumento;
                DocumentLicencia.dteVigenciaDocumento = numeroLicenciaManejoDM.dteVigenciaDocumento;

                documentacion.Add(DocumentLicencia);
                documentos.Add(documentosDM);
            }

            if (documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo de la Cartilla
                NumeroCartillaMilitarVM numeroCartillaMilitarVM = documentacionPersonalVM.NumeroCartillaMilitarVM;
                NumeroCartillaMilitarDomainModel numeroCartillaMilitarDM = new NumeroCartillaMilitarDomainModel();
                DocumentosVM documentosVMCartilla = numeroCartillaMilitarVM.DocumentosVM;
                DocumentosDomainModel documentosDMCartilla = new DocumentosDomainModel();

                //Mapeo de la Cartilla
                AutoMapper.Mapper.Map(numeroCartillaMilitarVM, numeroCartillaMilitarDM);
                AutoMapper.Mapper.Map(documentosVMCartilla, documentosDMCartilla);

                DocumentacionPersonalDomainModel DocumentCartilla = new DocumentacionPersonalDomainModel();
                DocumentCartilla.NumeroCartillaMilitarDM = numeroCartillaMilitarDM;
                DocumentCartilla.strIdentificador = numeroCartillaMilitarDM.strIdentificador;
                DocumentCartilla.strNumeroDocumento = numeroCartillaMilitarDM.strNumeroDocumento;
                DocumentCartilla.dteVigenciaDocumento = DateTime.MaxValue;

                documentacion.Add(DocumentCartilla);
                documentos.Add(documentosDMCartilla);
            }

            if (documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo del Pasaporte
                NumeroPasaporteVM numeroPasaporteVM = documentacionPersonalVM.NumeroPasaporteVM;
                NumeroPasaporteDomainModel numeroPasaporteDM = new NumeroPasaporteDomainModel();
                DocumentosVM documentosVMPasaporte = numeroPasaporteVM.DocumentosVM;
                DocumentosDomainModel documentosDMPasaporte = new DocumentosDomainModel();

                //Mapeo de la Pasaporte
                AutoMapper.Mapper.Map(numeroPasaporteVM, numeroPasaporteDM);
                AutoMapper.Mapper.Map(documentosVMPasaporte, documentosDMPasaporte);

                DocumentacionPersonalDomainModel DocumentPasaporte = new DocumentacionPersonalDomainModel();
                DocumentPasaporte.NumeroPasaporteDM = numeroPasaporteDM;
                DocumentPasaporte.strIdentificador = numeroPasaporteDM.strIdentificador;
                DocumentPasaporte.strNumeroDocumento = numeroPasaporteDM.strNumeroDocumento;
                DocumentPasaporte.dteVigenciaDocumento = numeroPasaporteDM.dteVigenciaDocumento;

                documentacion.Add(DocumentPasaporte);
                documentos.Add(documentosDMPasaporte);
            }

            if (documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo del Seguridad Social
                NumeroSeguridadSocialVM numeroSeguridadSocialVM = documentacionPersonalVM.NumeroSeguridadSocialVM;
                NumeroSeguridadSocialDomainModel numeroSeguridadSocialDM = new NumeroSeguridadSocialDomainModel();
                DocumentosVM documentosVMSeguridad = numeroSeguridadSocialVM.DocumentosVM;
                DocumentosDomainModel documentosDMSeguridad = new DocumentosDomainModel();

                //Mapeo de Seguridad Social
                AutoMapper.Mapper.Map(numeroSeguridadSocialVM, numeroSeguridadSocialDM);
                AutoMapper.Mapper.Map(documentosVMSeguridad, documentosDMSeguridad);

                DocumentacionPersonalDomainModel DocumentSeguridadSocial = new DocumentacionPersonalDomainModel();
                DocumentSeguridadSocial.NumeroSeguridadSocialDM = numeroSeguridadSocialDM;
                DocumentSeguridadSocial.strIdentificador = numeroSeguridadSocialDM.strIdentificador;
                DocumentSeguridadSocial.strNumeroDocumento = numeroSeguridadSocialDM.strNumeroDocumento;
                DocumentSeguridadSocial.dteVigenciaDocumento = numeroSeguridadSocialDM.dteVigenciaDocumento;

                documentacion.Add(DocumentSeguridadSocial);
                documentos.Add(documentosDMSeguridad);
            }

            if (documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo de Visa Canada
                NumeroVisaCanadaVM numeroVisaCanadaVM = documentacionPersonalVM.NumeroVisaCanadaVM;
                NumeroVisaCanadaDomainModel numeroVisaCanadaDM = new NumeroVisaCanadaDomainModel();
                DocumentosVM documentosVMVisaCanada = numeroVisaCanadaVM.DocumentosVM;
                DocumentosDomainModel documentosDMVisaCanada = new DocumentosDomainModel();

                //Mapeo de Visa Canada
                AutoMapper.Mapper.Map(numeroVisaCanadaVM, numeroVisaCanadaDM);
                AutoMapper.Mapper.Map(documentosVMVisaCanada, documentosDMVisaCanada);

                DocumentacionPersonalDomainModel DocumentVisaCanada = new DocumentacionPersonalDomainModel();
                DocumentVisaCanada.NumeroVisaCanadaDM = numeroVisaCanadaDM;
                DocumentVisaCanada.strIdentificador = numeroVisaCanadaDM.strIdentificador;
                DocumentVisaCanada.strNumeroDocumento = numeroVisaCanadaDM.strNumeroDocumento;
                DocumentVisaCanada.dteVigenciaDocumento = numeroVisaCanadaDM.dteVigenciaDocumento;

                documentacion.Add(DocumentVisaCanada);
                documentos.Add(documentosDMVisaCanada);
            }

            if (documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo de Visa USA
                NumeroVisaUsaVM numeroVisaUsaVM = documentacionPersonalVM.NumeroVisaUsaVM;
                NumeroVisaUsaDomainModel numeroVisaUsaDM = new NumeroVisaUsaDomainModel();
                DocumentosVM documentosVMVisaUSA = numeroVisaUsaVM.DocumentosVM;
                DocumentosDomainModel documentosDMVisaUSa = new DocumentosDomainModel();

                //Mapeo de Visa USA
                AutoMapper.Mapper.Map(numeroVisaUsaVM, numeroVisaUsaDM);
                AutoMapper.Mapper.Map(documentosVMVisaUSA, documentosDMVisaUSa);

                DocumentacionPersonalDomainModel DocumentVisaUSA = new DocumentacionPersonalDomainModel();
                DocumentVisaUSA.NumeroVisaUsaDM = numeroVisaUsaDM;
                DocumentVisaUSA.strIdentificador = numeroVisaUsaDM.strIdentificador;
                DocumentVisaUSA.strNumeroDocumento = numeroVisaUsaDM.strNumeroDocumento;
                DocumentVisaUSA.dteVigenciaDocumento = numeroVisaUsaDM.dteVigenciaDocumento;

                documentacion.Add(DocumentVisaUSA);
                documentos.Add(documentosDMVisaUSa);
            }

            if (documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo Registro Estatal
                RegistroProfEstatalVM registroProfEstatalVM = documentacionPersonalVM.RegistroProfEstatalVM;
                RegistroProfEstatalDomainModel registroProfEstatalDM = new RegistroProfEstatalDomainModel();
                DocumentosVM documentosVMRegistroEstatal = registroProfEstatalVM.DocumentosVM;
                DocumentosDomainModel documentosDMRegistroEstatal = new DocumentosDomainModel();

                //Mapeo Registro Estatal
                AutoMapper.Mapper.Map(registroProfEstatalVM, registroProfEstatalDM);
                AutoMapper.Mapper.Map(documentosVMRegistroEstatal, documentosDMRegistroEstatal);

                DocumentacionPersonalDomainModel DocumentRegistroEstatal = new DocumentacionPersonalDomainModel();
                DocumentRegistroEstatal.RegistroProfEstatalDM = registroProfEstatalDM;
                DocumentRegistroEstatal.strIdentificador = registroProfEstatalDM.strIdentificador;
                DocumentRegistroEstatal.strNumeroDocumento = registroProfEstatalDM.strNumeroDocumento;
                DocumentRegistroEstatal.dteVigenciaDocumento = registroProfEstatalDM.dteVigenciaDocumento;

                documentacion.Add(DocumentRegistroEstatal);
                documentos.Add(documentosDMRegistroEstatal);
            }

            if (documentacionPersonalVM.IfeVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo Ife
                IfeVM ifeVM = documentacionPersonalVM.IfeVM;
                IfeDomainModel ifeDM = new IfeDomainModel();
                DocumentosVM documentosVMIfe = ifeVM.DocumentosVM;
                DocumentosDomainModel documentosDMIfe = new DocumentosDomainModel();

                //Mapeo Ife
                AutoMapper.Mapper.Map(ifeVM, ifeDM);
                AutoMapper.Mapper.Map(documentosVMIfe, documentosDMIfe);

                DocumentacionPersonalDomainModel DocumentIfe = new DocumentacionPersonalDomainModel();
                DocumentIfe.IfeDM = ifeDM;
                DocumentIfe.strIdentificador = ifeDM.strIdentificador;
                DocumentIfe.dteVigenciaDocumento = DateTime.MaxValue;

                documentacion.Add(DocumentIfe);
                documentos.Add(documentosDMIfe);
            }

            if (documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo Comprobante Domicilio
                ComprobanteDomicilioVM comprobanteDomicilioVM = documentacionPersonalVM.ComprobanteDomicilioVM;
                ComprobanteDomicilioDomainModel comprobanteDomicilioDM = new ComprobanteDomicilioDomainModel();
                DocumentosVM documentosVMComprobante = comprobanteDomicilioVM.DocumentosVM;
                DocumentosDomainModel documentosDMComprobante = new DocumentosDomainModel();

                //Mapeo Comprobante Domicilio
                AutoMapper.Mapper.Map(comprobanteDomicilioVM, comprobanteDomicilioDM);
                AutoMapper.Mapper.Map(documentosVMComprobante, documentosDMComprobante);

                DocumentacionPersonalDomainModel DocumentComprobante = new DocumentacionPersonalDomainModel();
                DocumentComprobante.ComprobanteDomicilioDM = comprobanteDomicilioDM;
                DocumentComprobante.strIdentificador = comprobanteDomicilioDM.strIdentificador;
                DocumentComprobante.dteVigenciaDocumento = DateTime.MaxValue;

                documentacion.Add(DocumentComprobante);
                documentos.Add(documentosDMComprobante);
            }

            if (documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.StrUrl != null)
            {
                //Mapeo Solicitud Empleo
                SolicitudEmpleoVM solicitudEmpleoVM = documentacionPersonalVM.SolicitudEmpleoVM;
                SolicitudEmpleoDomainModel solicitudEmpleoDM = new SolicitudEmpleoDomainModel();
                DocumentosVM documentosVMSolicitud = solicitudEmpleoVM.DocumentosVM;
                DocumentosDomainModel documentosDMSolicitud = new DocumentosDomainModel();

                //Mapeo Solicitud Empleo
                AutoMapper.Mapper.Map(solicitudEmpleoVM, solicitudEmpleoDM);
                AutoMapper.Mapper.Map(documentosVMSolicitud, documentosDMSolicitud);

                DocumentacionPersonalDomainModel DocumentSolicitud = new DocumentacionPersonalDomainModel();
                DocumentSolicitud.SolicitudEmpleoDM = solicitudEmpleoDM;
                DocumentSolicitud.strIdentificador = solicitudEmpleoDM.strIdentificador;
                DocumentSolicitud.dteVigenciaDocumento = DateTime.MaxValue;

                documentacion.Add(DocumentSolicitud);
                documentos.Add(documentosDMSolicitud);
            }

            foreach (DocumentosDomainModel item in documentos)
            {
                DocumentosDomainModel documento = IdocumentosBusiness.AddDocumento(item);

                foreach (DocumentacionPersonalDomainModel itemD in documentacion)
                {
                    itemD.idDocumento = documento.IdDocumento;
                    itemD.idPersonal = SessionPersister.AccountSession.IdPersonal;
                    resultado = IdocumentacionPersonalBusiness.AddDocumentacionPersonal(itemD);
                    documentacion.Remove(itemD);
                    break;
                }
            }
            return resultado;
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
        [HttpPost]
        public ActionResult DeleteDocumentosById(DocumentosVM documentoVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            DocumentosDomainModel documentosDM = IdocumentosBusiness.GetDocumentoByIdDocumento(documentoVM.IdDocumento);

            if (documentosDM != null)
            {
                IdocumentacionPersonalBusiness.DeleteDocumentacionPersonal(documentosDM.IdDocumento,idPersonal);
                System.IO.File.Delete(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO+
                    SessionPersister.AccountSession.NombreCompleto+"/"+documentosDM.StrUrl));

                return RedirectToAction("Create","DocumentacionPersonal");
            }

            return RedirectToAction("Create", "DocumentacionPersonal");
        }
        [HttpGet]
        public ActionResult GetDocumentoById(int idDocumento)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            
            DocumentosDomainModel documentoDM = IdocumentosBusiness.GetDocumentoByIdDocumento(idDocumento);

            if (documentoDM != null)
            {
                DocumentosVM documentoVM = new DocumentosVM();
                AutoMapper.Mapper.Map(documentoDM, documentoVM);
                return PartialView("_Eliminar", documentoVM);
            }

            return View();
        }
    }
}