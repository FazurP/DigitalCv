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
    public class DocumentosProfesionalesBusiness : IDocumentosProfesionalesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentosProfesionalesRepository documentosProfesionalesRepository;

        public DocumentosProfesionalesBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            documentosProfesionalesRepository = new DocumentosProfesionalesRepository(unitOfWork);
        }

        public bool AddDocumentosProfesionales(DocumentosProfesionalesDomainModel documentosProfesionalesDomainModel)
        {
            bool respuesta = false;

            if (documentosProfesionalesDomainModel != null)
            {
                TblDocumentosProfesionales tblDocumentosProfesionales = new TblDocumentosProfesionales();

                if (documentosProfesionalesDomainModel.Type == 1)
                {
                    tblDocumentosProfesionales.idDoctorado = documentosProfesionalesDomainModel.idDoctorado;
                } else if (documentosProfesionalesDomainModel.Type == 2)
                {
                    tblDocumentosProfesionales.idMaestria = documentosProfesionalesDomainModel.idMaestria;
                } else if (documentosProfesionalesDomainModel.Type == 3)
                {
                    tblDocumentosProfesionales.idLicenciaturaIng = documentosProfesionalesDomainModel.idLicenciaturaIng;
                } else if (documentosProfesionalesDomainModel.Type == 4)
                {
                    tblDocumentosProfesionales.idLicenciaturaIng = documentosProfesionalesDomainModel.idLicenciaturaIng;
                } else if (documentosProfesionalesDomainModel.Type == 5)
                {
                    tblDocumentosProfesionales.idBachillerato = documentosProfesionalesDomainModel.idBachillerato;
                }

                tblDocumentosProfesionales.strNombre = documentosProfesionalesDomainModel.strNombre;

                documentosProfesionalesRepository.Insert(tblDocumentosProfesionales);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
