using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class DocumentacionPersonalBusiness : IDocumentacionPersonalBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentacionPersonalRepository documentacionPersonalRepository;
        public DocumentacionPersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            documentacionPersonalRepository = new DocumentacionPersonalRepository(unitOfWork);
        }

        public bool AddDocumentacionPersonal(DocumentacionPersonalDomainModel documentacionPersonalDM)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            tblPremiosDocente tblPremios = new tblPremiosDocente();
            tblDocumentacionPersonal tblDocumentacionPersonal = new tblDocumentacionPersonal();
            tblDocumentacionPersonal.idDocumento = documentacionPersonalDM.idDocumento;
            tblDocumentacionPersonal.idPersonal = documentacionPersonalDM.idPersonal;
            tblDocumentacionPersonal.strIdentificador = documentacionPersonalDM.NumeroLicenciaManejoDM.strIdentificador;
            tblDocumentacionPersonal.strNumeroDocumento = documentacionPersonalDM.NumeroLicenciaManejoDM.strNumeroDocumento;
            tblDocumentacionPersonal.dteVigenciaDocumento = documentacionPersonalDM.NumeroLicenciaManejoDM.dteVigenciaDocumento;

            documentacionPersonalRepository.Insert(tblDocumentacionPersonal);
            respuesta = true;
            return respuesta;
        }
    }
}
