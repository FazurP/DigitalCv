using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEnfermedadBusiness
    {
        /// <summary>
        /// este metodo se encarga de consultar todas las enfermedades den la base de datos.
        /// </summary>
        /// <returns>regresa una lista de enfermedades</returns>
        List<EnfermedadDomainModel> GetEnfermedades();
    }
}
