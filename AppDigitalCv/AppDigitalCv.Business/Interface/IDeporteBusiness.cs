using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDeporteBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los deportes posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de deportes</returns>
        List<DeporteDomainModel> GetDeportes();
    }
}
