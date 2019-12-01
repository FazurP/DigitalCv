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
        bool AddUpdateCompetencias(CompetenciasPersonalDomainModel competenciasPersonalDomainModel);
        List<CompetenciasPersonalDomainModel> GetAllCompetenciasPersonal(int _idPersonal);
        CompetenciasPersonalDomainModel GetCompetenciaPersonal(int _id);
        bool DeleteCompetenciaPersonal(CompetenciasPersonalDomainModel competenciasPersonalDomainModel);

    }
}
