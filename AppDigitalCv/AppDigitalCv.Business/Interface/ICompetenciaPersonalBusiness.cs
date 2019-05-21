using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICompetenciaPersonalBusiness
    {
        bool AddUpdateCompetencias(int _idPersonal, int _idCompetencia);
        List<CompetenciasDomainModel> GetCompetenciasByIdPersonal(int _idPersonal);
        CompetenciasPersonalDomainModel GetCompetenciaPersonal(int _idCompetencia, int _idPersonal);
        bool DeleteCompetencia(CompetenciasPersonalDomainModel competenciasPersonalDM);
    }
}
