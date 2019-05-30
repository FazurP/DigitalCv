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
    public class DocumentacionPersonalController : Controller
    {

        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;
        IDocumentacionPersonalBusiness IdocumentacionPersonalBusiness;
        DocumentosPersonalesParam documentosPersonalesParam = new DocumentosPersonalesParam();
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
            documentacionPersonalVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

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

            if (ModelState.IsValid)
            {
                this.CrearDocumentoPersonales(documentacionPersonalVM);
                return RedirectToAction("Create", "DocumentacionPersonal");
            }
            else{
                return RedirectToAction("Create", "DocumentacionPersonal");
            }

        }

        public void CrearDocumentoPersonales(DocumentacionPersonalVM documentacionPersonalVM)
        {
            PersonalDomainModel personalDM = this.GetPersonalVM(documentacionPersonalVM.idPersonal);
            documentacionPersonalVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = personalDM.Nombre + " " + personalDM.ApellidoPaterno + " " + personalDM.ApellidoMaterno;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));
            string path2 = "";
            string path3 = "";
            string path4 = "";
            string path5 = "";
            string path6 = "";
            string path7 = "";
            string path8 = "";
            string path9 = "";
            string path10 = "";

            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName));
                path2 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName));
                path3 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName));
                path4 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName));
                path5 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName));
                path6 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName));
                path7 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName));
                path8 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName));
                path9 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName));
                path10 = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto + "/"), Path.GetFileName(documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName));

                string sfpath = documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath2 = documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath3 = documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath4 = documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath5 = documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath6 = documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath7 = documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath8 = documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath9 = documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.FileName;
                string sfpath10 = documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.FileName;

                documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM.DocumentoFile.SaveAs(path);
                documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM.DocumentoFile.SaveAs(path2);
                documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM.DocumentoFile.SaveAs(path3);
                documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM.DocumentoFile.SaveAs(path4);
                documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM.DocumentoFile.SaveAs(path5);
                documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM.DocumentoFile.SaveAs(path6);
                documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM.DocumentoFile.SaveAs(path7);
                documentacionPersonalVM.IfeVM.DocumentosVM.DocumentoFile.SaveAs(path8);
                documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM.DocumentoFile.SaveAs(path9);
                documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM.DocumentoFile.SaveAs(path10);

                DocumentosVM documentoVM = new DocumentosVM();
                DocumentosVM documentoVM2 = new DocumentosVM();
                DocumentosVM documentoVM3 = new DocumentosVM();
                DocumentosVM documentoVM4 = new DocumentosVM();
                DocumentosVM documentoVM5 = new DocumentosVM();
                DocumentosVM documentoVM6 = new DocumentosVM();
                DocumentosVM documentoVM7 = new DocumentosVM();
                DocumentosVM documentoVM8 = new DocumentosVM();
                DocumentosVM documentoVM9 = new DocumentosVM();
                DocumentosVM documentoVM10 = new DocumentosVM();

                documentoVM.StrUrl = sfpath;
                documentoVM2.StrUrl = sfpath2;
                documentoVM3.StrUrl = sfpath3;
                documentoVM4.StrUrl = sfpath4;
                documentoVM5.StrUrl = sfpath5;
                documentoVM6.StrUrl = sfpath6;
                documentoVM7.StrUrl = sfpath7;
                documentoVM8.StrUrl = sfpath8;
                documentoVM9.StrUrl = sfpath9;
                documentoVM10.StrUrl = sfpath10;

                documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM = documentoVM;
                documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM = documentoVM2;
                documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM = documentoVM3;
                documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM = documentoVM4;
                documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM = documentoVM5;
                documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM = documentoVM6;
                documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM = documentoVM7;
                documentacionPersonalVM.IfeVM.DocumentosVM = documentoVM8;
                documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM = documentoVM9;
                documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM = documentoVM10;
                this.AddEditDocumentosPersonales(documentacionPersonalVM);
            }
        }

        public bool AddEditDocumentosPersonales(DocumentacionPersonalVM documentacionPersonalVM)
        {
            bool resultado = false;

            DocumentacionPersonalDomainModel documentacionPersonalDomainModel = new DocumentacionPersonalDomainModel();
            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();

            //Mapeo de la Licencia
            NumeroLicenciaManejoVM numeroLicenciaManejoVM = documentacionPersonalVM.NumeroLicenciaManejoVM;
            NumeroLicenciaManejoDomainModel numeroLicenciaManejoDM = new NumeroLicenciaManejoDomainModel();
            DocumentosVM documentosVM = numeroLicenciaManejoVM.DocumentosVM;
            DocumentosDomainModel documentosDM = new DocumentosDomainModel();

            //Mapeo de la Cartilla
            NumeroCartillaMilitarVM numeroCartillaMilitarVM = documentacionPersonalVM.NumeroCartillaMilitarVM;
            NumeroCartillaMilitarDomainModel numeroCartillaMilitarDM = new NumeroCartillaMilitarDomainModel();
            DocumentosVM documentosVMCartilla = numeroCartillaMilitarVM.DocumentosVM;
            DocumentosDomainModel documentosDMCartilla = new DocumentosDomainModel();

            //Mapeo del Pasaporte
            NumeroPasaporteVM numeroPasaporteVM = documentacionPersonalVM.NumeroPasaporteVM;
            NumeroPasaporteDomainModel numeroPasaporteDM = new NumeroPasaporteDomainModel();
            DocumentosVM documentosVMPasaporte = numeroPasaporteVM.DocumentosVM;
            DocumentosDomainModel documentosDMPasaporte = new DocumentosDomainModel();

            //Mapeo del Seguridad Social
            NumeroSeguridadSocialVM numeroSeguridadSocialVM = documentacionPersonalVM.NumeroSeguridadSocialVM;
            NumeroSeguridadSocialDomainModel numeroSeguridadSocialDM = new NumeroSeguridadSocialDomainModel();
            DocumentosVM documentosVMSeguridad = numeroSeguridadSocialVM.DocumentosVM;
            DocumentosDomainModel documentosDMSeguridad = new DocumentosDomainModel();

            //Mapeo de Visa Canada
            NumeroVisaCanadaVM numeroVisaCanadaVM = documentacionPersonalVM.NumeroVisaCanadaVM;
            NumeroVisaCanadaDomainModel numeroVisaCanadaDM = new NumeroVisaCanadaDomainModel();
            DocumentosVM documentosVMVisaCanada = numeroVisaCanadaVM.DocumentosVM;
            DocumentosDomainModel documentosDMVisaCanada = new DocumentosDomainModel();

            //Mapeo de Visa USA
            NumeroVisaUsaVM numeroVisaUsaVM = documentacionPersonalVM.NumeroVisaUsaVM;
            NumeroVisaUsaDomainModel numeroVisaUsaDM = new NumeroVisaUsaDomainModel();
            DocumentosVM documentosVMVisaUSA = numeroVisaUsaVM.DocumentosVM;
            DocumentosDomainModel documentosDMVisaUSa = new DocumentosDomainModel();

            //Mapeo Registro Estatal
            RegistroProfEstatalVM registroProfEstatalVM = documentacionPersonalVM.RegistroProfEstatalVM;
            RegistroProfEstatalDomainModel registroProfEstatalDM = new RegistroProfEstatalDomainModel();
            DocumentosVM documentosVMRegistroEstatal = registroProfEstatalVM.DocumentosVM;
            DocumentosDomainModel documentosDMRegistroEstatal = new DocumentosDomainModel();

            //Mapeo Ife
            IfeVM ifeVM = documentacionPersonalVM.IfeVM;
            IfeDomainModel ifeDM = new IfeDomainModel();
            DocumentosVM documentosVMIfe = ifeVM.DocumentosVM;
            DocumentosDomainModel documentosDMIfe = new DocumentosDomainModel();

            //Mapeo Comprobante Domicilio
            ComprobanteDomicilioVM comprobanteDomicilioVM = documentacionPersonalVM.ComprobanteDomicilioVM;
            ComprobanteDomicilioDomainModel comprobanteDomicilioDM = new ComprobanteDomicilioDomainModel();
            DocumentosVM documentosVMComprobante = comprobanteDomicilioVM.DocumentosVM;
            DocumentosDomainModel documentosDMComprobante = new DocumentosDomainModel();

            //Mapeo Solicitud Empleo
            SolicitudEmpleoVM solicitudEmpleoVM = documentacionPersonalVM.SolicitudEmpleoVM;
            SolicitudEmpleoDomainModel solicitudEmpleoDM = new SolicitudEmpleoDomainModel();
            DocumentosVM documentosVMSolicitud = solicitudEmpleoVM.DocumentosVM;
            DocumentosDomainModel documentosDMSolicitud = new DocumentosDomainModel();


            //Mappeo de la Licencia
            AutoMapper.Mapper.Map(numeroLicenciaManejoVM, numeroLicenciaManejoDM);//Aqui
            AutoMapper.Mapper.Map(documentosVM, documentosDM);//Aqui
            //Mapeo de la Cartilla
            AutoMapper.Mapper.Map(numeroCartillaMilitarVM, numeroCartillaMilitarDM);
            AutoMapper.Mapper.Map(documentosVMCartilla, documentosDMCartilla);
            //Mapeo de la Pasaporte
            AutoMapper.Mapper.Map(numeroPasaporteVM, numeroPasaporteDM);
            AutoMapper.Mapper.Map(documentosVMPasaporte, documentosDMPasaporte);
            //Mapeo de Seguridad Social
            AutoMapper.Mapper.Map(numeroSeguridadSocialVM, numeroSeguridadSocialDM);
            AutoMapper.Mapper.Map(documentosVMSeguridad, documentosDMSeguridad);
            //Mapeo de Visa Canada
            AutoMapper.Mapper.Map(numeroVisaCanadaVM, numeroVisaCanadaDM);
            AutoMapper.Mapper.Map(documentosVMVisaCanada, documentosDMVisaCanada);
            //Mapeo de Visa USA
            AutoMapper.Mapper.Map(numeroVisaUsaVM, numeroVisaUsaDM);
            AutoMapper.Mapper.Map(documentosVMVisaUSA, documentosDMVisaUSa);
            //Mapeo Registro Estatal
            AutoMapper.Mapper.Map(registroProfEstatalVM, registroProfEstatalDM);
            AutoMapper.Mapper.Map(documentosVMRegistroEstatal, documentosDMRegistroEstatal);
            //Mapeo Ife
            AutoMapper.Mapper.Map(ifeVM, ifeDM);
            AutoMapper.Mapper.Map(documentosVMIfe, documentosDMIfe);
            //Mapeo Comprobante Domicilio
            AutoMapper.Mapper.Map(comprobanteDomicilioVM, comprobanteDomicilioDM);
            AutoMapper.Mapper.Map(documentosVMComprobante, documentosDMComprobante);
            //Mapeo Solicitud Empleo
            AutoMapper.Mapper.Map(solicitudEmpleoVM, solicitudEmpleoDM);
            AutoMapper.Mapper.Map(documentosVMSolicitud, documentosDMSolicitud);

            DocumentacionPersonalDomainModel DocumentLicencia = new DocumentacionPersonalDomainModel();
            DocumentLicencia.NumeroLicenciaManejoDM = numeroLicenciaManejoDM;

            DocumentacionPersonalDomainModel DocumentCartilla = new DocumentacionPersonalDomainModel();
            DocumentCartilla.NumeroCartillaMilitarDM = numeroCartillaMilitarDM;

            DocumentacionPersonalDomainModel DocumentPasaporte = new DocumentacionPersonalDomainModel();
            DocumentPasaporte.NumeroPasaporteDM = numeroPasaporteDM;

            DocumentacionPersonalDomainModel DocumentSeguridadSocial = new DocumentacionPersonalDomainModel();
            DocumentSeguridadSocial.NumeroSeguridadSocialDM = numeroSeguridadSocialDM;

            DocumentacionPersonalDomainModel DocumentVisaCanada = new DocumentacionPersonalDomainModel();
            DocumentVisaCanada.NumeroVisaCanadaDM = numeroVisaCanadaDM;

            DocumentacionPersonalDomainModel DocumentVisaUSA = new DocumentacionPersonalDomainModel();
            DocumentVisaUSA.NumeroVisaUsaDM = numeroVisaUsaDM;

            DocumentacionPersonalDomainModel DocumentRegistroEstatal = new DocumentacionPersonalDomainModel();
            DocumentRegistroEstatal.RegistroProfEstatalDM = registroProfEstatalDM;

            DocumentacionPersonalDomainModel DocumentIfe = new DocumentacionPersonalDomainModel();
            DocumentIfe.IfeDM = ifeDM;

            DocumentacionPersonalDomainModel DocumentComprobante = new DocumentacionPersonalDomainModel();
            DocumentComprobante.ComprobanteDomicilioDM = comprobanteDomicilioDM;

            DocumentacionPersonalDomainModel DocumentSolicitud = new DocumentacionPersonalDomainModel();
            DocumentSolicitud.SolicitudEmpleoDM = solicitudEmpleoDM;



            List<DocumentacionPersonalDomainModel> documentacion = new List<DocumentacionPersonalDomainModel>();
            documentacion.Add(DocumentLicencia);
            documentacion.Add(DocumentCartilla);
            documentacion.Add(DocumentPasaporte);
            documentacion.Add(DocumentSeguridadSocial);
            documentacion.Add(DocumentVisaCanada);
            documentacion.Add(DocumentVisaUSA);
            documentacion.Add(DocumentRegistroEstatal);
            documentacion.Add(DocumentIfe);
            documentacion.Add(DocumentComprobante);
            documentacion.Add(DocumentSolicitud);

            List<DocumentosDomainModel> documentos = new List<DocumentosDomainModel>();
            documentos.Add(documentosDM);
            documentos.Add(documentosDMCartilla);
            documentos.Add(documentosDMPasaporte);
            documentos.Add(documentosDMSeguridad);
            documentos.Add(documentosDMVisaCanada);
            documentos.Add(documentosDMVisaUSa);
            documentos.Add(documentosDMRegistroEstatal);
            documentos.Add(documentosDMIfe);
            documentos.Add(documentosDMComprobante);
            documentos.Add(documentosDMSolicitud);

            foreach (DocumentosDomainModel item in documentos)
            {
                DocumentosDomainModel documento = IdocumentosBusiness.AddDocumento(item);

                foreach (DocumentacionPersonalDomainModel documents in documentacion)
                {
                    resultado = IdocumentacionPersonalBusiness.AddDocumentacionPersonal(documents);
                }
                
            }

            //AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM, documentosDomainModel);
            //documentacionPersonalDomainModel.NumeroLicenciaManejoDM.DocumentosDM = documentosDomainModel;

            //DocumentosDomainModel documento = IdocumentosBusiness.AddDocumento(documentosDomainModel);
            //documentacionPersonalDomainModel.idDocumento = documento.IdDocumento;
            //resultado = IdocumentacionPersonalBusiness.AddDocumentacionPersonal(documentacionPersonalDomainModel);

            return resultado;
        }
 
        public PersonalDomainModel GetPersonalVM(int idPersonal)
        {
            PersonalDomainModel personalDM = IpersonalBusiness.GetPersonalById(idPersonal);
            return personalDM;
        }
    }
}