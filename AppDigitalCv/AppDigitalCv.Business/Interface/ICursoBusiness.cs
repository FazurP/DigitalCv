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
    }
}
