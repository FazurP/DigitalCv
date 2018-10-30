using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEstadoBusiness
    {

        /// <summary>
        /// Este metodo se encarga de obtener la lista de estados
        /// </summary>
        /// <returns> regresa una lista de direcciones con el estado cargado </returns>
        List<EstadoDomainModel> GetEstado();
        List<EstadoDomainModel> GetEstadoByIdPais(int idPais);
    }
}
