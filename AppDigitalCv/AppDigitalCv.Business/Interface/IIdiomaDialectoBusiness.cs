using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IIdiomaDialectoBusiness
    {
        List<IdiomaDomainModel> GetIdioma();
        List<IdiomaDialectoDomainModel> GetIdiomaDialecto();
        bool AddUpdateIdioma(IdiomaDialectoDomainModel idiomaDialectoDM);
    }
}
