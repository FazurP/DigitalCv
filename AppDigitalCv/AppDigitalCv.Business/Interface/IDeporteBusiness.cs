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
        
        /// <summary>
        /// Este metodo se encarga de agregar una entidad del tipo catdeporte
        /// </summary>
        /// <param name="deporteDM">entidad que se va agregar al modelo de base de datos</param>
        /// <returns>un valor booleano</returns>
        bool AddUpdateCompetenciaTi(DeporteDomainModel deporteDM);
    }
}
