using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEmergenciaBusiness
    {
        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="emergenciaDM">recibe una entidad del tipo de emergencia domain model</param>
        /// <returns>una cadena de confirmación de inserción</returns>
        string AddUpdateEmergencia(EmergenciaDomianModel emergenciaDM);
    }
}
