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
        /// <summary>
        /// Este metodo se ecarga de insertar o actualizar una entidad del tipo InstitucionSuperiorDomainModel
        /// </summary>
        /// <param name="InstitucionSuperiorDomainModel">Entidad del tipo InstitucionSuperiorDomainModel</param>
        /// <returns>una cadena de confirmación</returns>
        string AddUpdateInstitucionSuperior(InstitucionSuperiorDomainModel institucionSuperiorDM);
    }
}
