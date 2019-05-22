using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IInstitucionSuperiorBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas las instituciones superiores del catalogo de la base de datos
        /// </summary>
        /// <returns>lista de instituciones superiores</returns>
        List<InstitucionSuperiorDomainModel> GetInstitucionSuperior();
    }
}
