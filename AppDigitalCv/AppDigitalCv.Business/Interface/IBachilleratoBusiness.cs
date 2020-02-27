using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IBachilleratoBusiness
    {
        int addBachillerato(HistorialAcademicoDomainModel historialAcademico);
        List<BachilleratoDomainModel> GetBachillerato(int idPersonal);
        BachilleratoDomainModel GetBachilleratos(int _id);
        bool DeleteBachillerato(HistorialAcademicoDomainModel historialAcademicoDomainModel);
    }
}
