using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEstadoCivilBusiness
    {
        /// <summary>
        /// Metodo encargado de obtener todos los estados civiles desde la base de datos
        /// </summary>
        /// <returns> regresa una lista de los estados civiles  </returns>
        List<EstadoCivilDomainModel> GetEstadoCivil();

        string AddUpdateEstadocivil(PersonalDomainModel personaDM);
    }
}
