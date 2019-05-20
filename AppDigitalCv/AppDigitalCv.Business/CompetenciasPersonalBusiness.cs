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

        public CompetenciasPersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            competenciasRepository = new CompetenciasPersonalRepository(unitOfWork);
        }

        public bool AddUpdateCompetencias(int idPersonal, int idCompetencia)
        {
            bool respuesta = false;
            string resultado = string.Empty;

            tblCompetenciasConocimientosPersonal tblCompetenciasPersonal = new tblCompetenciasConocimientosPersonal();
            tblCompetenciasPersonal.idPersonal = idPersonal;
            tblCompetenciasPersonal.idCompetencia = idCompetencia;
            tblCompetenciasPersonal.dteFechaRegistro = DateTime.Now;
            competenciasRepository.Insert(tblCompetenciasPersonal);
            respuesta = true;
            return respuesta;
        }

        public List<CompetenciasDomainModel> GetCompetenciasByIdPersonal(int _idPersonal) {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            Expression<Func<tblCompetenciasConocimientosPersonal, bool>> predicado = p => p.idPersonal.Equals(_idPersonal);
            List<tblCompetenciasConocimientosPersonal> tblCompetencia = competenciasRepository.GetAll(predicado).ToList<tblCompetenciasConocimientosPersonal>();


            foreach (tblCompetenciasConocimientosPersonal competencia in tblCompetencia)
            {
                CompetenciasDomainModel competenciaDM = new CompetenciasDomainModel();
                competenciaDM.idCompetencia = competencia.catCompetencias.idCompetencia;
                competenciaDM.strDescripcion = competencia.catCompetencias.strDescripcion;
                competenciaDM.strObservacion = competencia.catCompetencias.strObservacion;
                competenciaDM.strTipo = competencia.catCompetencias.strTipo;
                competenciasDM.Add(competenciaDM);
            }

            return competenciasDM;
        }
    }
}
