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
        /// <summary>
        /// Este metodo se encarga de eliminar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="IdEmergencia">el identificador de la entidad a eliminar</param>
        /// <returns>regresa un valor booleano true o false dependiendo la condición</returns>
        bool DeleteContactoEmergencia(int IdEmergencia);
        /// <summary>
        /// Este metodo se encarga de consultar los los datos de conatcto de emergencia 
        /// </summary>
        /// <param name="idPersonal">recive el identificador de la emergencia del personal</param>
        /// <returns>regresa una lista de los Emergencia en la entidad domain model</returns>
        List<EmergenciaDomianModel> GetEmergenciasById(int idPersonal);
    }
}
