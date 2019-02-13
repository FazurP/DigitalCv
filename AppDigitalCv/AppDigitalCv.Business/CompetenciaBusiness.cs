using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;

namespace AppDigitalCv.Business
{
    public class CompetenciaBusiness: ICompetenciaBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly CompetenciaTiRepository competenciaRepository;

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades de una competencia en ti
        /// </summary>
        /// <returns>una lista de competencias en ti</returns>
        public List<CompetenciaTiDomainModel> GetCompetenciasTi()
        {
            List<CompetenciaTiDomainModel> lista = null;
            lista = competenciaRepository.GetAll().Select(p => new CompetenciaTiDomainModel
            {
                IdCompetenciaTI = p.idCompetenciaTI,
                StrDescripcion = p.strDescripcion,
                StrObservacion = p.strObservacion
                
            }).ToList();
            return lista;
        }
    }
}
