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
        /// <summary>
        /// Este metodo se encarga de obtener una lista de estados por medio de un pais
        /// </summary>
        /// <param name="idPais">Pide el id del pais </param>
        /// <returns> Regresa una lista de estados </returns>
        List<EstadoDomainModel> GetEstadoByIdPais(int idPais);
    }
}
