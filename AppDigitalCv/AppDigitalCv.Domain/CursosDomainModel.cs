using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppDigitalCv.Domain
{
    public class CursosDomainModel
    {
        public int Id { get; set; }
        public CursoDomainModel CursoDomainModel { get; set; }
        public InstitucionSuperiorDomainModel InstitucionSuperiorDomainModel { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public int IdPersonal { get; set; }
        public string StrUrlDocumento { get; set; }
        public HttpPostedFileWrapper DocumentoPDF { get; set; }
        //atributos de el id del curso y el id de la institucion
        public int IdCurso { get; set; }
        public int IdInstitucionSuperior { get; set; }
    }
}
