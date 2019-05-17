using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDialectoBusiness
    {
        List<DialectoDomainModel> GetDialectosByIdPersonal(int _idPersonal);

        DialectoDomainModel GetDialecto(int idDielecto, int idPersona);
    }
}
