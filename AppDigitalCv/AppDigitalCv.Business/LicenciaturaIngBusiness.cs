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
    public class LicenciaturaIngBusiness : ILicenciaturaIngBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LecenciaturaIngenieriaRepository lecenciaturaIngenieriaRepository;
        private readonly DocumentosRepository documentosRepository;

        public LicenciaturaIngBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            lecenciaturaIngenieriaRepository = new LecenciaturaIngenieriaRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddLicenciaturaIng(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel != null)
            {
                catDocumentos catDocumentos = new catDocumentos();
                TblLicenciaturaIngenieria tblLicenciaturaIngenieria = new TblLicenciaturaIngenieria();

                tblLicenciaturaIngenieria.idIstitucionAcreditaLicenciatura = historialAcademicoDomainModel.InstitucionAcredita;
                tblLicenciaturaIngenieria.idPersonal = historialAcademicoDomainModel.idPersonal;
                tblLicenciaturaIngenieria.idStatusLicenciatura = historialAcademicoDomainModel.Status;
                tblLicenciaturaIngenieria.strNombre = historialAcademicoDomainModel.strNombre;

                catDocumentos.TblLicenciaturaIngenieria.Add(tblLicenciaturaIngenieria);

                catDocumentos.strUrl = historialAcademicoDomainModel.Documentos.DocumentoFile.FileName;

                documentosRepository.Insert(catDocumentos);
                respuesta = true;

            }

            return respuesta;
        }

        public List<LicenciaturaIngenieriaDomainModel> GetLicenciaturasIngs(int idPersonal)
        {
            List<LicenciaturaIngenieriaDomainModel> licenciaturaIngenieriaDomainModels = new List<LicenciaturaIngenieriaDomainModel>();
            List<TblLicenciaturaIngenieria> tblLicenciaturaIngenierias = new List<TblLicenciaturaIngenieria>();

            tblLicenciaturaIngenierias = lecenciaturaIngenieriaRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (TblLicenciaturaIngenieria item in tblLicenciaturaIngenierias)
            {
                LicenciaturaIngenieriaDomainModel licenciaturaIngenieriaDomainModel = new LicenciaturaIngenieriaDomainModel();

                licenciaturaIngenieriaDomainModel.id = item.id;
                licenciaturaIngenieriaDomainModel.idDocumento = item.idDocumento.Value;
                licenciaturaIngenieriaDomainModel.idInstitucionAcredita = item.idIstitucionAcreditaLicenciatura.Value;
                licenciaturaIngenieriaDomainModel.idPersonal = item.idPersonal.Value;
                licenciaturaIngenieriaDomainModel.idStatusLicenciatura = item.idStatusLicenciatura.Value;
                licenciaturaIngenieriaDomainModel.strNombre = item.strNombre;
                licenciaturaIngenieriaDomainModel.Documentos = new DocumentosDomainModel { StrUrl = item.catDocumentos.strUrl};
                licenciaturaIngenieriaDomainModel.InstitucionAcreditaLicenciatura = new InstitucionAcreditaLicenciaturaDomainModel
                {
                    id = item.CatInstitucionAcreditaLicenciatura.id,
                    strDescripcion = item.CatInstitucionAcreditaLicenciatura.strDescripcion,
                    strValor =item.CatInstitucionAcreditaLicenciatura.strValor
                };
                licenciaturaIngenieriaDomainModel.StatusLicenciatura = new StatusLicenciaturaDomainModel
                {
                    id = item.CatStatusLicenciatura.id,
                    strDescripcion = item.CatStatusLicenciatura.strDescripcion,
                    strValor =item.CatStatusLicenciatura.strValor
                };
                licenciaturaIngenieriaDomainModels.Add(licenciaturaIngenieriaDomainModel);
            }

            return licenciaturaIngenieriaDomainModels;
        }
    }
}
