using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICompetenciaBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades de una competencia en ti
        /// </summary>
        /// <returns>una lista de competencias en ti</returns>
        List<CompetenciaTiDomainModel> GetCompetenciasTi();
    }
}
