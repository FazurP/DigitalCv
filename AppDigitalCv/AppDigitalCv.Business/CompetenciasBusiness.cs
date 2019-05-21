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
    public class CompetenciasBusiness : ICompetenciasBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly CompetenciasRepository competenciasRepository;
        private readonly CompetenciasPersonalRepository competenciasPersonalRepository;

        public CompetenciasBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            competenciasRepository = new CompetenciasRepository(unitOfWork);
            competenciasPersonalRepository = new CompetenciasPersonalRepository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de obtener las competencias de tipo Habilidad
        /// </summary>
        /// <returns>una lista con las competencias</returns>
        public List<CompetenciasDomainModel> GetCompetenciasHabilidad() {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Habilidad")).ToList();

            return competenciasDM;

        }
        /// <summary>
        /// Este metodo se encarga de obtener las competancias de tipo Destraza
        /// </summary>
        /// <returns>una lista con las competancias</returns>
        public List<CompetenciasDomainModel> GetCompetenciasDestreza()
        {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Destreza")).ToList();

            return competenciasDM;

        }
        /// <summary>
        /// Este metodo se encarga de obtener las competencias de tipo Valor
        /// </summary>
        /// <returns>una lista con las competancias</returns>
        public List<CompetenciasDomainModel> GetCompetenciasValor()
        {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Valor")).ToList();

            return competenciasDM;

        }
        /// <summary>
        /// Este metodo se encarga de obtener un objeto de competencia mediante el ID de la competencia y del personal
        /// </summary>
        /// <param name="idCompetencia"></param>
        /// <param name="idPersona"></param>
        /// <returns>un objeto de la competencia</returns>
        public CompetenciasDomainModel GetCompetencia(int idCompetencia, int idPersona)
        {

            CompetenciasDomainModel competenciaDM = new CompetenciasDomainModel();

            Expression<Func<tblCompetenciasConocimientosPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersona) && p.idCompetencia.Equals(idCompetencia);
            tblCompetenciasConocimientosPersonal tblCompetencias = competenciasPersonalRepository.GetAll(predicado).FirstOrDefault<tblCompetenciasConocimientosPersonal>();

            competenciaDM.idCompetencia = tblCompetencias.catCompetencias.idCompetencia;
            competenciaDM.strDescripcion = tblCompetencias.catCompetencias.strDescripcion;
            competenciaDM.strObservacion = tblCompetencias.catCompetencias.strObservacion;
            competenciaDM.strTipo = tblCompetencias.catCompetencias.strTipo;

            return competenciaDM;

        }

    }
}
