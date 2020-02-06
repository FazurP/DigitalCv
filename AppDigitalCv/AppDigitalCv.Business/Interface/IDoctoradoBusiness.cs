using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDoctoradoBusiness
    {
        bool AddDoctorado(HistorialAcademicoDomainModel historialAcademico);
        List<DoctoradoDomainModel> GetDoctorados(int idPersonal);
        DoctoradoDomainModel GetDoctorado(int idDoctorado);
        bool DeleteDoctorado(HistorialAcademicoDomainModel historialAcademicoDomainModel);
    }
}
