using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IIdiomasBusiness
    {
        bool AddUpdateIdioma(IdiomasDomainModel idiomasDomainModel);

        List<IdiomasDomainModel> GetAllIdiomasByPersonal(int _idPersonal);
        IdiomasDomainModel GetIdiomaById(int _id);
        bool DeleteIdioma(IdiomasDomainModel idiomasDomainModel);
    }
}
