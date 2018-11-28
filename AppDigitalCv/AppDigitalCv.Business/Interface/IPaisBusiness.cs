using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPaisBusiness
    {
        /// <summary>
        /// Este metodo se encarga de obtener la lista de paises
        /// </summary>
        /// <returns> regresa una lista de direcciones con el pais cargado </returns>
        List<PaisDomainModel> GetPais();
    }
}
