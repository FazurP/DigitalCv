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
    public class BachilleratoBusiness : IBachilleratoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BachilleratoRepository bachilleratoRepository;
        private readonly DocumentosRepository documentosRepository;
        private readonly PersonalRepository personalRepository;

        public BachilleratoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            bachilleratoRepository = new BachilleratoRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
            personalRepository = new PersonalRepository(unitOfWork);
        }

        public int addBachillerato(HistorialAcademicoDomainModel historialAcademico)
        {
            tblPersonal tblPersonal = personalRepository.SingleOrDefault(p => p.idPersonal == historialAcademico.idPersonal);

            if (tblPersonal.idBachillerato == null)
            {
                if (historialAcademico != null)
                {
                    TblBachillerato tblBachillerato = new TblBachillerato();

                    tblBachillerato.strInstitucionAcreditaBachillerato = historialAcademico.strNombre;

                    bachilleratoRepository.Insert(tblBachillerato);

                    tblPersonal.idBachillerato = tblBachillerato.id;

                    personalRepository.Update(tblPersonal);

                    return tblBachillerato.id;
                }
            }          
            return 0;
        }

        public List<BachilleratoDomainModel> GetBachillerato(int idPersonal)
        {
            tblPersonal tblPersonal = new tblPersonal();
            List<BachilleratoDomainModel> bachilleratoDomainModels = new List<BachilleratoDomainModel>();
            tblPersonal = personalRepository.SingleOrDefault(p => p.idPersonal == idPersonal);

            if (tblPersonal.TblBachillerato != null)
            {
                BachilleratoDomainModel bachilleratoDomainModel = new BachilleratoDomainModel();               

                bachilleratoDomainModel.id = tblPersonal.TblBachillerato.id;
                bachilleratoDomainModel.strNombre = tblPersonal.TblBachillerato.strInstitucionAcreditaBachillerato;

                bachilleratoDomainModels.Add(bachilleratoDomainModel);
            }
          
            return bachilleratoDomainModels;
        }

        public BachilleratoDomainModel GetBachilleratos(int _id)
        {
            BachilleratoDomainModel bachilleratoDomainModel = new BachilleratoDomainModel();

            TblBachillerato tblBachillerato = bachilleratoRepository.SingleOrDefault(p => p.id == _id);

            bachilleratoDomainModel.id = tblBachillerato.id;
            bachilleratoDomainModel.strNombre = tblBachillerato.strInstitucionAcreditaBachillerato;
            bachilleratoDomainModel.DocumentosProfesionales = new List<DocumentosProfesionalesDomainModel>();
            foreach (var item in tblBachillerato.TblDocumentosProfesionales)
            {
                DocumentosProfesionalesDomainModel documentosProfesionalesDomainModel = new DocumentosProfesionalesDomainModel();

                documentosProfesionalesDomainModel.strNombre = item.strNombre;
                documentosProfesionalesDomainModel.id = item.id;

                bachilleratoDomainModel.DocumentosProfesionales.Add(documentosProfesionalesDomainModel);
            }

            return bachilleratoDomainModel;
        }

        public bool DeleteBachillerato(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel.Bachillerato.id > 0)
            {
                bachilleratoRepository.Delete(p => p.id == historialAcademicoDomainModel.Bachillerato.id);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
