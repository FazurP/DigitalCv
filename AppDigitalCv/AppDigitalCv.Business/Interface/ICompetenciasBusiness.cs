using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICompetenciasBusiness
    {
        List<CompetenciasDomainModel> GetCompetenciasHabilidad();
        List<CompetenciasDomainModel> GetCompetenciasDestreza();
        List<CompetenciasDomainModel> GetCompetenciasValor();
        CompetenciasDomainModel GetCompetencia(int idCompetencia, int idPersona);
    }
}
