using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IFamiliarBusiness
    {
        /// <summary>
        ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="familiarDM">recive una entidad familiar</param>
        /// <returns>regresa una cadena con la respuesta de la transacción</returns>
        bool AddUpdateFamiliar(FamiliarDomainModel familiarDM);

        /// <summary>
        /// Este metodo se encarga de obtener el famlair y su identificador a traves del nombre
        /// </summary>
        /// <param name="familiarDM">recibe una entidad del tipo FamiliarDomainModel</param>
        /// <returns>regresa una entidad del tipo FamiliarDomainModel</returns>
        FamiliarDomainModel GetFamiliarByNombre(FamiliarDomainModel familiarDM);
        /// <summary>
        /// Este metodo se encarga de consultar los hijos o familaires de una persona
        /// </summary>
        /// <param name="idPersonal">recive el identificador de la persona</param>
        /// <returns>regresa una lista de los familiares en la entidad domain model</returns>
        List<FamiliarDomainModel> GetFamiliaresHijosById(int idPersonal);
        
        /// <summary>
        /// Este metodo se encarga de buscar un familiar por el identificador del familiar
        /// </summary>
        /// <param name="idFamiliar">identificador del familiar</param>
        /// <returns>regresa la entidad  del tipo FamiliarDomainModel</returns>
        FamiliarDomainModel GetFamiliarByIdFamiliar(int idFamiliar);
        
        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un familiar d ela base de datos
        /// </summary>
        /// <param name="familiarDomainModel">recive una entidad del tipo familiarDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        bool DeleteFamiliar(FamiliarDomainModel familiarDomainModel);
    }
}
