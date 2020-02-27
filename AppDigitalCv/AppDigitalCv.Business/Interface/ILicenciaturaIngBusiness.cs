using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ILicenciaturaIngBusiness
    {
        int AddLicenciaturaIng(HistorialAcademicoDomainModel historialAcademicoDomainModel);
        List<LicenciaturaIngenieriaDomainModel> GetLicenciaturasIngs(int idPersonal);
        List<StatusLicenciaturaDomainModel> GetStatusLicenciaturas();
        bool DeleteLicenciarturaIng(HistorialAcademicoDomainModel historialAcademicoDomainModel);
        LicenciaturaIngenieriaDomainModel GetLicenciaturaIng(int _id);
    }
}
