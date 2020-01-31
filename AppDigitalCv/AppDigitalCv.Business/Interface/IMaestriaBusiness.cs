using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IMaestriaBusiness
    {
        bool AddMaestria(HistorialAcademicoDomainModel historialAcademicoDomainModel);
        List<MaestriaDomainModel> GetMaestrias(int idPersonal);
    }
}
