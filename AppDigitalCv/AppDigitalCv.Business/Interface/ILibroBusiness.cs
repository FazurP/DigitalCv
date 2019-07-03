using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ILibroBusiness
    {
        bool AddUpdateLibro(LibroDomainModel libroDM);
        List<LibroDomainModel> GetLibrosByPersonal(int _idPersonal);
        LibroDomainModel GetLibro(int _idLibro);

        bool DeleteLibro(int _idLibro);
    }
}
