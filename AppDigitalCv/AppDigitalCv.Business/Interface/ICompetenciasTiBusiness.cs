using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICompetenciasTiBusiness
    {
        /// <summary>
        ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="idCompetencia">recibe el identificador de la competencia como parametro</param>
        /// <returns>regresa un valor bool con la respuesta de la transacción</returns>
        bool AddUpdateCompetenciaTi(int idPersonal, int idCompetencia);
        
        /// <summary>
        /// Este metodo se encarga de consultar todas las competencias de TI del personal por identificador
        /// </summary>
        /// <param name="idPersonal">identificador del personal</param>
        /// <returns>regresa una lista de  competencias</returns>
        List<CompetenciasTiDomainModel> GetCompetenciasTi(int idPersonal);
    }
}
