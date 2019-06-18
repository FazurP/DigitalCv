using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IExperienciaLaboralInternaBusiness
    {
        bool AddUpdateExperienciaLaboralInterna(ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM);
        List<ExperienciaLaboralInternaDomainModel> GetExperienciasByPersonal(int _idPersonal);
        ExperienciaLaboralInternaDomainModel GetExperiencia(int _idPersonal, int _idExperiencia);
        bool DeleteExperiencias(int _idPersonal, int _idExperiencia);
    }
}
