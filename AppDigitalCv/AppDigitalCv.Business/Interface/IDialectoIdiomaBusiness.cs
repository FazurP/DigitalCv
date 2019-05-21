using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDialectoIdiomaBusiness
    {
        List<DialectoDomainModel> GetDialecto();
        bool AddUpdateDialecto(IdiomaDialectoDomainModel dialectoIdiomaDM);

        IdiomaDialectoDomainModel GetDialectoPersonales(int _idDialecto, int _idPersonal);

        bool DeleteDialectoDialectos(IdiomaDialectoDomainModel idiomaDialectoDM);

    }
}
