using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICapacitacionesImpartidasBusiness
    {
        bool AddCapacitacion(CapacitacionesImpartidadDomainModel capacitacionesImpartidaDomainModel);
        List<CapacitacionesImpartidadDomainModel> GetCapacitacionesImpartidas(int _idPersonal);
        CapacitacionesImpartidadDomainModel GetCapacitacionImpartida(int _id);
    }
}
