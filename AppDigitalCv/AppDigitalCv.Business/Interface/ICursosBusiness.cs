using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ICursosBusiness
    {
        /// <summary>
        /// Este metodo se encarga de agregar nuevos cursos ala tabla principal
        /// </summary>
        /// <param name="cursosDM">una entidad del tipo cursos</param>
        /// <returns>una cadena de confirmación</returns>
        string AddUpdateCursos(CursosDomainModel cursosDM);
        
        /// <summary>
        /// Este metodo se encarga de consultar los cursos personales de un personal de la institucion
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>regresa una lista de todos los cursos</returns>
        List<CursosDomainModel> GetCursosPersonalesById(int idPersonal);

        /// <summary>
        /// Este metodo se encarga de consultar el curso de una persona por id
        /// </summary>
        /// <param name="Id">el identificador del curso</param>
        /// <returns>una entidad del tipo cursosdomainmodel</returns>
        CursosDomainModel GetCursoPersonalById(int Id);
    }
}
