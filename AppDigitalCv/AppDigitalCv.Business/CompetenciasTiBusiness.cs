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
                competencia.DteFechaRegistro = t.dteFechaRegistro;
                competencia.IdCompetenciaTI = t.idCompetenciaTI;
                competencia.IdCompetenciaTIPersonal = t.idCompetenciaTIPersonal;
                competencia.IdPersonal = t.idPersonal;

                CompetenciaTiDomainModel competenciaTi = new CompetenciaTiDomainModel();
                competenciaTi.StrDescripcion = t.catCompetenciaTI.strDescripcion;
                competencia.CompetenciaTiDomainModel = competenciaTi;
                competenciasTI.Add(competencia);
            }
            return competenciasTI;
            /*
            competenciasRepository.GetAll().
                Select(p => new CompetenciasTiDomainModel
                {
                    IdCompetenciaTI = p.idCompetenciaTI,
                    IdCompetenciaTIPersonal = p.idCompetenciaTIPersonal,
                    DteFechaRegistro = p.dteFechaRegistro,
                    IdPersonal = p.idPersonal
                });*/
        }


    }
}
