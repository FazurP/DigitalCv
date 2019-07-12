using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IManualOperacionBusiness
    {
        bool AddUpdateManualOperacion(ManualOperacionDomainModel manualOperacionDM);
        List<ManualOperacionDomainModel> GetManualesByPersonal(int _idPersonal);
        ManualOperacionDomainModel GetManualOperacion(int _idManual);
        bool DeleteManualOperacion(int _idManual);
    }
}
