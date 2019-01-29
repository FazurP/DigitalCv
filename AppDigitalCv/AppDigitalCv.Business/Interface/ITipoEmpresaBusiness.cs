using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ITipoEmpresaBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar el tipo de empresa por el idAsociacion
        /// </summary>
        /// <param name="idTipoEmpresa">el identificador del tipo empresa</param>
        /// <returns>retorna una lista del tipo de empresas consultadas</returns>
        List<TipoEmpresaDomainModel> GetTipoEmpresaByIdEmpresa(int idTipoEmpresa);
        
        /// <summary>
        /// Este metodo se encarga de consultar unaempresa por el id de la Asociacion
        /// </summary>
        /// <param name="idAsociacion">el identificador de la asociacion</param>
        /// <returns>una lista del tipo empresa</returns>
        List<TipoEmpresaDomainModel> GetTipoEmpresaByIdAsociacion(int idAsociacion);
    }
}
