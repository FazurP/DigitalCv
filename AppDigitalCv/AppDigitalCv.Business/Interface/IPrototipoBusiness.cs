using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPrototipoBusiness
    {
        bool AddUpdatePrototipo(PrototipoDomainModel prototipoDomainModel);

        List<PrototipoDomainModel> GetPrototipos(int _idPersonal);

        PrototipoDomainModel GetPrototipoById(int _idPrototipo);

        bool DeletePrototipoById(int _idPrototipo);
    }
}
