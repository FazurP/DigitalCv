using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IFrecuenciaBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos la Frecuencia con la que se realizan actividades posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de Frecuencias</returns>
        List<FrecuenciaDomainModel> GetFrecuencia();
    }
}
