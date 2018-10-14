using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPersonalBusiness
    {
        /// <summary>
        /// obtiene todos los empleados
        /// </summary>
        /// <returns>rfegresa una lista de personal en la capa del modelo de dominio</returns>
        List<PersonalDomainModel> GetEmpleado();
        /// <summary>
        /// agrega o actualiza los datos de una entidad personal
        /// </summary>
        /// <param name="personalDM">recibe un objeto del modelo de dominio</param>
        /// <returns>regresa un mensaje con el resultado de la accion realizada</returns>
        string AddUpdatePersonal(PersonalDomainModel personalDM);
        /// <summary>
        /// este metodo se encarga de consultar a una persona por id
        /// </summary>
        /// <param name="idPersonal">recibe el id del personal a buscar</param>
        /// <returns>regresa una entidad del modelo de dominio</returns>
        PersonalDomainModel GetPersonalById(int idPersonal);
    }
}
