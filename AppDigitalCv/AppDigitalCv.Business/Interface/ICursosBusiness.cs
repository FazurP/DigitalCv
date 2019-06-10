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
    }
}
