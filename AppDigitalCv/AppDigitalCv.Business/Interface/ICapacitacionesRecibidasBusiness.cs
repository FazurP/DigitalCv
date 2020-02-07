using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICapacitacionesRecibidasBusiness
    {
        bool AddCapacitacion(CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel);
        List<CapacitacionesRecibidasDomainModel> GetCapacitacionesRecibidas(int _idPersonal);
        CapacitacionesRecibidasDomainModel GetCapacitacionRecibida(int _id);
        bool DeleteCapacitacion(CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel);
    }
}
