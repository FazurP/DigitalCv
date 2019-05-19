using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICompetenciaPersonalBusiness
    {
        bool AddUpdateCompetencias(int idPersonal, int idCompetencia);
    }
}
