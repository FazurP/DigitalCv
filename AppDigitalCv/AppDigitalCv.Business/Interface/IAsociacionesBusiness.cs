using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IAsociacionesBusiness
    {
        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        string AddUpdateAsociaciones(AsociacionesDomainModel asociacionesDM);
        
        /// <summary>
        /// Este metodo se encarga de obtener todas las entidades del tipo asociaciones
        /// </summary>
        /// <returns>retorna una lista de asociaciones</returns>
        List<AsociacionesDomainModel> GetAsociaciones();
    }
}
