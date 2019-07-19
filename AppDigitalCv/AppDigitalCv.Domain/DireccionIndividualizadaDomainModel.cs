using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DireccionIndividualizadaDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public int idTipoEstudio { get; set; }
        public int idInstitucionSuperior { get; set; }
        public string strTituloTesis { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public string strNumeroAlumnos { get; set; }
        public string strEstadoDireccionIndividualizada { get; set; }
        public bool bitConsideraCurriculum { get; set; }
    }
}
