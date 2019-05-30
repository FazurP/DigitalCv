using AppDigitalCv.Business;
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
using System.ComponentModel.DataAnnotations;

namespace AppDigitalCv.Models
{
    public class DocumentosPersonalesParam : Controller
    {

        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;
        IDocumentacionPersonalBusiness IdocumentacionPersonalBusiness;    
        public DocumentosPersonalesParam(IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness
            ,IDocumentacionPersonalBusiness _IdocumentacionPersonalBusiness)
        {
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
            IdocumentacionPersonalBusiness = _IdocumentacionPersonalBusiness;
        }

        public DocumentosPersonalesParam() { }

        [NonAction]
        public void CreatePath(DocumentacionPersonalVM documentacionPersonalVM)
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
        [NonAction]
        public bool AddEditDocumentosPersonales(DocumentacionPersonalVM documentacionPersonalVM)
        {
            bool resultado = false;

            DocumentacionPersonalDomainModel documentacionPersonalDomainModel = new DocumentacionPersonalDomainModel();

            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel2 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel3 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel4 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel5 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel6 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel7 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel8 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel9 = new DocumentosDomainModel();
            DocumentosDomainModel documentosDomainModel10 = new DocumentosDomainModel();

            AutoMapper.Mapper.Map(documentacionPersonalVM, documentacionPersonalDomainModel);//Aqui

            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroLicenciaManejoVM.DocumentosVM, documentosDomainModel);
            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroCartillaMilitarVM.DocumentosVM, documentosDomainModel2);
            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroPasaporteVM.DocumentosVM, documentosDomainModel3);
            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroSeguridadSocialVM.DocumentosVM, documentosDomainModel4);
            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroVisaCanadaVM.DocumentosVM, documentosDomainModel5);
            AutoMapper.Mapper.Map(documentacionPersonalVM.NumeroVisaUsaVM.DocumentosVM, documentosDomainModel6);
            AutoMapper.Mapper.Map(documentacionPersonalVM.RegistroProfEstatalVM.DocumentosVM, documentosDomainModel7);
            AutoMapper.Mapper.Map(documentacionPersonalVM.IfeVM.DocumentosVM, documentosDomainModel8);
            AutoMapper.Mapper.Map(documentacionPersonalVM.ComprobanteDomicilioVM.DocumentosVM, documentosDomainModel9);
            AutoMapper.Mapper.Map(documentacionPersonalVM.SolicitudEmpleoVM.DocumentosVM, documentosDomainModel10);

            documentacionPersonalDomainModel.NumeroLicenciaManejoDM.DocumentosDM = documentosDomainModel;
            documentacionPersonalDomainModel.NumeroCartillaMilitarDM.DocumentosDM = documentosDomainModel2;
            documentacionPersonalDomainModel.NumeroPasaporteDM.DocumentosDM = documentosDomainModel3;
            documentacionPersonalDomainModel.NumeroSeguridadSocialDM.DocumentosDM = documentosDomainModel4;
            documentacionPersonalDomainModel.NumeroVisaCanadaDM.DocumentosDM = documentosDomainModel5;
            documentacionPersonalDomainModel.NumeroVisaUsaDM.DocumentosDM = documentosDomainModel6;
            documentacionPersonalDomainModel.RegistroProfEstatalDM.DocumentosDM = documentosDomainModel7;
            documentacionPersonalDomainModel.IfeDM.DocumentosDM = documentosDomainModel8;
            documentacionPersonalDomainModel.ComprobanteDomicilioDM.DocumentosDM = documentosDomainModel9;
            documentacionPersonalDomainModel.SolicitudEmpleoDM.DocumentosDM = documentosDomainModel10;

            DocumentosDomainModel documento = IdocumentosBusiness.AddDocumento(documentosDomainModel);
            documentacionPersonalDomainModel.idDocumento = documento.IdDocumento;
            resultado = IdocumentacionPersonalBusiness.AddDocumentacionPersonal(documentacionPersonalDomainModel);

            return resultado;
        }
        [NonAction]
        public PersonalDomainModel GetPersonalVM(int idPersonal)
        {
            PersonalDomainModel personalDM = IpersonalBusiness.GetPersonalById(idPersonal);
            return personalDM;
        }
    }
}