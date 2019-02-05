using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPersonalAsociacionesBusiness
    {
        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        string AddUpdatePersonalAsociaciones(PersonalAsociacionesDomainModel personalAsociacionesDM);

        /// <summary>
        /// este metodo sirve para agregar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        string AddPersonalAsociaciones(PersonalAsociacionesDomainModel personalAsociacionesDM);


        /// <summary>
        /// Este metodo se encarga de obtener todas las asociaciones del personal
        /// </summary>
        /// <param name="idPersonal">el identificador de personal</param>
        /// <returns>regresa una lista de premios del tipo domain model</returns>
        List<PersonalAsociacionesDomainModel> GetPersonalAsociacinesById(int idPersonal);

        /// <summary>
        /// Este metodo se encarga de obtener una asociacion del personal por identificador
        /// </summary>
        /// <param name="idAsociacion">el identificador d ela asociacion</param>
        /// <returns>una entidad del personal asociacion</returns>
        PersonalAsociacionesDomainModel GetPersonalAsociacionByIdAsociacion(int idAsociacion);


        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente una asociacion del docente de la base de datos
        /// </summary>
        /// <param name="personalAsociacionesDomainModel">recive una entidad del tipo personalAsociacionesDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        bool DeleteAsociacionDocente(PersonalAsociacionesDomainModel personalAsociacionesDomainModel);
    }
}
