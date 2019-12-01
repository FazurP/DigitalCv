using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class CompetenciasPersonalBusiness : ICompetenciaPersonalBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly CompetenciasPersonalRepository competenciasRepository;
        private readonly DocumentosRepository documentosRepository;

        public CompetenciasPersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            competenciasRepository = new CompetenciasPersonalRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddUpdateCompetencias(CompetenciasPersonalDomainModel competenciasPersonalDomainModel)
        {
            bool respuesta = false;

                catDocumentos catDocumentos = new catDocumentos();
                tblCompetenciasConocimientosPersonal tblCompetenciasConocimientosPersonal = new tblCompetenciasConocimientosPersonal();

                tblCompetenciasConocimientosPersonal.dteFechaRegistro = DateTime.Now;
                tblCompetenciasConocimientosPersonal.idPersonal = competenciasPersonalDomainModel.idPersonal;

                catDocumentos.tblCompetenciasConocimientosPersonal.Add(tblCompetenciasConocimientosPersonal);
                catDocumentos.strUrl = competenciasPersonalDomainModel.file.StrUrl;
              

                documentosRepository.Insert(catDocumentos);
                respuesta = true;
            
            return respuesta;
        }

        public List<CompetenciasPersonalDomainModel> GetAllCompetenciasPersonal(int _idPersonal) 
        {
            List<CompetenciasPersonalDomainModel> competenciasPersonalDomainModels = new List<CompetenciasPersonalDomainModel>();

            List<tblCompetenciasConocimientosPersonal> tblCompetencias = new List<tblCompetenciasConocimientosPersonal>();

            tblCompetencias = competenciasRepository.GetAll().Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (tblCompetenciasConocimientosPersonal item in tblCompetencias)
            {
                CompetenciasPersonalDomainModel competenciasPersonalDomainModel = new CompetenciasPersonalDomainModel();

                competenciasPersonalDomainModel.dteFechaRegistroString = item.dteFechaRegistro.Value.ToShortDateString();
                competenciasPersonalDomainModel.idCompetenciasConocimientosPersonal = item.idCompetenciasConocimientosPersonal;
                competenciasPersonalDomainModel.idDocumento = item.idDocumento.Value;
                competenciasPersonalDomainModel.idPersonal = item.idPersonal;
                competenciasPersonalDomainModel.file = new DocumentosDomainModel { StrUrl = item.catDocumentos.strUrl};

                competenciasPersonalDomainModels.Add(competenciasPersonalDomainModel);
            }

            return competenciasPersonalDomainModels;
        }

        public CompetenciasPersonalDomainModel GetCompetenciaPersonal(int _id) 
        {
            CompetenciasPersonalDomainModel competenciasPersonalDomainModel = new CompetenciasPersonalDomainModel();

            tblCompetenciasConocimientosPersonal tblCompetenciasConocimientosPersonal = new tblCompetenciasConocimientosPersonal();

            tblCompetenciasConocimientosPersonal = competenciasRepository.GetAll().FirstOrDefault(p => p.idCompetenciasConocimientosPersonal==_id);

            competenciasPersonalDomainModel.idPersonal = tblCompetenciasConocimientosPersonal.idPersonal;
            competenciasPersonalDomainModel.idDocumento = tblCompetenciasConocimientosPersonal.idDocumento.Value;
            competenciasPersonalDomainModel.idCompetenciasConocimientosPersonal = tblCompetenciasConocimientosPersonal.idCompetenciasConocimientosPersonal;
            competenciasPersonalDomainModel.dteFechaRegistro = tblCompetenciasConocimientosPersonal.dteFechaRegistro.Value;
            competenciasPersonalDomainModel.file = new DocumentosDomainModel { StrUrl = tblCompetenciasConocimientosPersonal.catDocumentos.strUrl };

            return competenciasPersonalDomainModel;
        }

        public bool DeleteCompetenciaPersonal(CompetenciasPersonalDomainModel competenciasPersonalDomainModel) 
        {
            bool respuesta = false;

            if (competenciasPersonalDomainModel.idCompetenciasConocimientosPersonal > 0)
            {
                documentosRepository.Delete(p => p.idDocumento == competenciasPersonalDomainModel.idDocumento);
                respuesta = true;
            }

            return respuesta;
        }
    }

}

