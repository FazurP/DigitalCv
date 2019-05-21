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
        /// <summary>
        /// Este metodo se encarga de insertar una competencia personal
        /// </summary>
        /// <param name="idPersonal"></param>
        /// <param name="idCompetencia"></param>
        /// <returns></returns>
        public bool AddUpdateCompetencias(int _idPersonal, int _idCompetencia)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            if (competenciasRepository.Exists(p => p.idCompetencia == _idCompetencia && p.idPersonal == _idPersonal))
            {
                return false;
            }
            else { 
            tblCompetenciasConocimientosPersonal tblCompetenciasPersonal = new tblCompetenciasConocimientosPersonal();
            tblCompetenciasPersonal.idPersonal = _idPersonal;
            tblCompetenciasPersonal.idCompetencia = _idCompetencia;
            tblCompetenciasPersonal.dteFechaRegistro = DateTime.Now;
            competenciasRepository.Insert(tblCompetenciasPersonal);
            respuesta = true;
            return respuesta;
            }
        }
        /// <summary>
        /// Este metodo se encarga de obtener las competencias del personal mediante su ID
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <returns>una lista con las competencias</returns>
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
        /// <summary>
        /// Este metodo se encarga de obtener una competencia personal mediante el ID de la competencia y el ID del personal
        /// </summary>
        /// <param name="_idCompetencia"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>un objeto de competencia personal</returns>
        public CompetenciasPersonalDomainModel GetCompetenciaPersonal(int _idCompetencia, int _idPersonal)
        {

            CompetenciasPersonalDomainModel competenciasPersonalDM = new CompetenciasPersonalDomainModel();
            Expression<Func<tblCompetenciasConocimientosPersonal, bool>> predicado = p => p.idCompetencia.Equals(_idCompetencia) && p.idPersonal.Equals(_idPersonal);
            tblCompetenciasConocimientosPersonal tblCompetencias = competenciasRepository.GetAll(predicado).FirstOrDefault<tblCompetenciasConocimientosPersonal>();

            competenciasPersonalDM.idCompetenciasConocimientosPersonal = tblCompetencias.idCompetenciasConocimientosPersonal;
            competenciasPersonalDM.idCompetencia = tblCompetencias.idCompetencia;
            competenciasPersonalDM.idPersonal = tblCompetencias.idPersonal;
            competenciasPersonalDM.dteFechaRegistro = tblCompetencias.dteFechaRegistro.Value;

            return competenciasPersonalDM;

        }
        /// <summary>
        /// Este metodo se encarga de eliminar una competencia personal mediante el objeto recibido
        /// </summary>
        /// <param name="competenciasPersonalDM"></param>
        /// <returns>true o false</returns>
        public bool DeleteCompetencia(CompetenciasPersonalDomainModel competenciasPersonalDM)
        {

            bool respuesta = false;
            Expression<Func<tblCompetenciasConocimientosPersonal, bool>> predicado = p => p.idCompetencia.Equals(competenciasPersonalDM.idCompetencia)
             && p.idPersonal.Equals(competenciasPersonalDM.idPersonal);
            competenciasRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }
    }
}
