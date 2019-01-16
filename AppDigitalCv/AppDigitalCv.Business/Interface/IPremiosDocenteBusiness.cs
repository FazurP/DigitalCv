using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    /// <summary>
    ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
    /// </summary>
    /// <param name="premiosDocenteDM">recive una entidad PremiosDocente</param>
    /// <returns>regresa un valor bool con la respuesta de la transacción</returns>
    public interface IPremiosDocenteBusiness
    {
        bool AddUpdatePremiosDocente(PremiosDocenteDomainModel premiosDocenteDM);
    }
}
