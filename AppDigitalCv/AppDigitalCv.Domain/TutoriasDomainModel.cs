using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class TutoriasDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public int idProgramaEductivo { get; set; }
        public string strNombreEstudantes { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public string strEstadoTutoria { get; set; }
        public string strTipo { get; set; }
        public string strHoras { get; set; }
    }
}
