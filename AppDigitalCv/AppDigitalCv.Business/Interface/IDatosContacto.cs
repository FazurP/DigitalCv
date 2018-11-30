using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDatosContacto
    {
        /// <summary>
        /// Este metodo se encarga de agregar o actualizar los datos de contacto de una persona
        /// </summary>
        /// <param name="datosContactoDM">recibe un objeto del tipo datos de contacto</param>
        /// <returns>regresa un valor booleano</returns>
         bool AddUpdateDatosContacto(DatosContactoDomainModel datosContactoDM);
        /// <summary>
        /// Este metodo se encarga de obtener los datos de contacto de una persona
        /// </summary>
        /// <param name="idPersonal">recibe un int que es el identificador del personal</param>
        /// <returns>regresa una entidad de tipo DatosContactoDomainModel</returns>
        List<DatosContactoDomainModel> GetDatosDeContacto(int idPersonal);
        /// <summary>
        /// Este metodo se encarga de obtener los datos de conatcto de una persona
        /// </summary>
        /// <param name="idPersonal">recibe un int que es el identificador del personal</param>
        /// <returns>regresa una entidad de tipo DatosContactoDomainModel</returns>
        DatosContactoDomainModel GetDatosContacto(int idPersonal);
    }
}
