using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ITelefono
    {
        /// <summary>
        /// Este metodo se encarga de agregar la entidad telefono a la base de datos
        /// </summary>
        /// <param name="datosContactoDM">recibe la entidad a insertar en la base de datos</param>
        /// <returns>regresa un valor booleano</returns>
        bool AddUpdateTelefono(DatosContactoDomainModel datosContactoDM);
    }
}
