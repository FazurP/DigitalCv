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
    public class CompetenciasTiBusiness: ICompetenciasTiBusiness
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly CompetenciasTiPersonalRepository competenciasRepository;

        public CompetenciasTiBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            competenciasRepository = new CompetenciasTiPersonalRepository(unitOfWork);
        }

        /// <summary>
        ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="idCompetencia">recibe el identificador de la competencia como parametro</param>
        /// <returns>regresa un valor bool con la respuesta de la transacción</returns>
        public bool AddUpdateCompetenciaTi(int idPersonal, int idCompetencia)
        {
            bool respuesta = false;
            string resultado = string.Empty;

            tblCompetenciasTIPersonal tblCompetenciasTI = new tblCompetenciasTIPersonal();
            tblCompetenciasTI.idPersonal = idPersonal;
            tblCompetenciasTI.idCompetenciaTI = idCompetencia;
            tblCompetenciasTI.dteFechaRegistro = DateTime.Now;
            competenciasRepository.Insert(tblCompetenciasTI);
            respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de consultar todas las competencias de TI del personal por identificador
        /// </summary>
        /// <param name="idPersonal">identificador del personal</param>
        /// <returns>regresa una lista de  competencias</returns>
        public List<CompetenciasTiDomainModel> GetCompetenciasTi(int idPersonal)
        {
            Expression<Func<tblCompetenciasTIPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            List<CompetenciasTiDomainModel> competenciasTI = new List<CompetenciasTiDomainModel>();
            List<tblCompetenciasTIPersonal> competencias = competenciasRepository.GetAll(predicado).ToList();
            foreach (tblCompetenciasTIPersonal t in competencias)
            {
                CompetenciasTiDomainModel competencia = new CompetenciasTiDomainModel();
                competencia.DteFechaRegistro = t.dteFechaRegistro.ToString();
                competencia.IdCompetenciaTI = t.idCompetenciaTI;
                competencia.IdCompetenciaTIPersonal = t.idCompetenciaTIPersonal;
                competencia.IdPersonal = t.idPersonal;

                CompetenciaTiDomainModel competenciaTi = new CompetenciaTiDomainModel();
                competenciaTi.StrDescripcion = t.catCompetenciaTI.strDescripcion;
                competencia.CompetenciaTiDomainModel = competenciaTi;
                competenciasTI.Add(competencia);
            }
            return competenciasTI;
            
        }


        /// <summary>
        /// Este metodo se encarga de buscar una competencia por el identificador de la competencia TI
        /// </summary>
        /// <param name="idCompetenciaTI">identificador de la competencia en TI</param>
        /// <returns>regresa la entidad  del tipo CompetenciasTIDomainModel</returns>
        public CompetenciasTiDomainModel GetCompetenciaTIByIdCompetencia(int IdCompetenciaTIPersonal)
        {
            Expression<Func<tblCompetenciasTIPersonal, bool>> predicado = p => p.idCompetenciaTIPersonal.Equals(IdCompetenciaTIPersonal);
            tblCompetenciasTIPersonal competenciaTI = competenciasRepository.SingleOrDefault(predicado);

            CompetenciasTiDomainModel competenciaTIDM = new CompetenciasTiDomainModel();
            competenciaTIDM.IdCompetenciaTI = competenciaTI.idCompetenciaTI;
            competenciaTIDM.IdPersonal = competenciaTI.idPersonal;
            competenciaTIDM.DteFechaRegistro = competenciaTI.dteFechaRegistro.ToString();
            competenciaTIDM.IdCompetenciaTIPersonal = competenciaTI.idCompetenciaTIPersonal;
            competenciaTIDM.CompetenciaTiDomainModel = new CompetenciaTiDomainModel();
            competenciaTIDM.CompetenciaTiDomainModel.IdCompetenciaTI = competenciaTI.catCompetenciaTI.idCompetenciaTI;
            competenciaTIDM.CompetenciaTiDomainModel.StrDescripcion = competenciaTI.catCompetenciaTI.strDescripcion;
            
            return competenciaTIDM;
            
        }

        /// <summary>
        /// Este metodo se encarga de eliminar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="IdCompetenciaTIPersonal">el identificador de la entidad a eliminar</param>
        /// <returns>regresa un valor booleano true o false dependiendo la condición</returns>
        public bool DeleteCompetenciaTiPersonal(int IdCompetenciaTIPersonal)
        {
            bool respuesta = false;
            Expression<Func<tblCompetenciasTIPersonal, bool>> predicado = p => p.idCompetenciaTIPersonal.Equals(IdCompetenciaTIPersonal);
            competenciasRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }




    }
}
