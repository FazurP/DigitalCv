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
        int AddMaestria(HistorialAcademicoDomainModel historialAcademicoDomainModel);
        List<MaestriaDomainModel> GetMaestrias(int idPersonal);
        MaestriaDomainModel GetMaestria(int _id);
        bool DeleteMaestria(HistorialAcademicoDomainModel historialAcademicoDomainModel);
    }
}
