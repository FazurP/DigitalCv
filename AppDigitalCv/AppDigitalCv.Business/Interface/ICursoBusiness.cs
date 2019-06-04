using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICursoBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los cursos del catalogo correspondiente
        /// </summary>
        /// <returns>una lista de cursos consultados</returns>
        List<CursoDomainModel> GetCursos();

        /// <summary>
        /// Este metodo se ecarga de insertar o actualizar una entidad del tipo curso
        /// </summary>
        /// <param name="cursoDM">Entidad del tipo CursoDomainModel</param>
        /// <returns>una cadena de confirmación</returns>
        string AddUpdateCurso(CursoDomainModel cursoDM);
    }
}
