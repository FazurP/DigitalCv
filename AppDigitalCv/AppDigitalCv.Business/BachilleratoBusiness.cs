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

        public bool addBachillerato(HistorialAcademicoDomainModel historialAcademico)
        {
            bool respuesta = false;
            tblPersonal tblPersonal = personalRepository.SingleOrDefault(p => p.idPersonal == historialAcademico.idPersonal);

            if (tblPersonal.idBachillerato == null)
            {
                if (historialAcademico != null)
                {
                    catDocumentos catDocumentos = new catDocumentos();
                    TblBachillerato tblBachillerato = new TblBachillerato();

                    tblBachillerato.strInstitucionAcreditaBachillerato = historialAcademico.strNombre;
                    catDocumentos.strUrl = historialAcademico.Documentos.DocumentoFile.FileName;

                    catDocumentos.TblBachillerato.Add(tblBachillerato);

                    documentosRepository.Insert(catDocumentos);
                    respuesta = true;
                }
            }          
            return respuesta;
        }

        public List<BachilleratoDomainModel> GetBachillerato(int idPersonal)
        {
            tblPersonal tblPersonal = new tblPersonal();
            List<BachilleratoDomainModel> bachilleratoDomainModels = new List<BachilleratoDomainModel>();
            tblPersonal = personalRepository.SingleOrDefault(p => p.idPersonal == idPersonal);

            if (tblPersonal.TblBachillerato != null)
            {
                BachilleratoDomainModel bachilleratoDomainModel = new BachilleratoDomainModel();
                

                bachilleratoDomainModel.Documentos = new DocumentosDomainModel
                {
                    StrUrl = tblPersonal.TblBachillerato.catDocumentos.strUrl
                };
                bachilleratoDomainModel.id = tblPersonal.TblBachillerato.id;
                bachilleratoDomainModel.idDocumento = tblPersonal.TblBachillerato.idDocumento.Value;
                bachilleratoDomainModel.strNombre = tblPersonal.TblBachillerato.strInstitucionAcreditaBachillerato;

                bachilleratoDomainModels.Add(bachilleratoDomainModel);
            }
          
            return bachilleratoDomainModels;
        }
    }
}
