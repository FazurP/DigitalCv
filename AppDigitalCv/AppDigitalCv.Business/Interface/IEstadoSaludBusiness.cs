using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEstadoSaludBusiness
    {
        //este metodo sirve para agregar o editar un registro de el contexto seleccionado
        string AddUpdateEstadoSalud(EstadoSaludDomainModel estadoSaludDM);
        /// <summary>
        /// Este metodo se encarga de consultar todas las enfermedades de una persona
        /// </summary>
        /// <returns>regresa una lista de enfermedades de una persona</returns>
        List<EstadoSaludDomainModel> GetEnfermedadesPersonalById(int idPersonal);
        /// <summary>
        /// Este metodo se encarga de consultar un estado de salud por el identificador de la enfermedad
        /// </summary>
        /// <param name="IdEnfermedad">identificador de la enfermedad</param>
        /// <returns>estado de salud domain model de la consulta</returns>
        EstadoSaludDomainModel GetEnfermedadesByIdEnfermedad(int IdEnfermedad);
        
        /// <summary>
        /// Este metodo se encarga de eliminar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="IdEnfermedad">el identificador de la entidad a eliminar</param>
        /// <returns>regresa un valor booleano true o false dependiendo la condición</returns>
        bool DeleteEstadoSaludPersonal(int IdEnfermedad);

    }
}
