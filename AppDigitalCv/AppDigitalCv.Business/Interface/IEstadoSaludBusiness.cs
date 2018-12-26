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
    }
}
