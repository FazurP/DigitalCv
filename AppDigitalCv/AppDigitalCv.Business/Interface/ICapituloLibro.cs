using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICapituloLibro
    {
        bool AddUpdateCapituloLibro(CapituloLibroDomainModel capituloLibroDomainModel);
        List<CapituloLibroDomainModel> GetCapitulosLibrosByPersonal(int _idPersonal);
    }
}
