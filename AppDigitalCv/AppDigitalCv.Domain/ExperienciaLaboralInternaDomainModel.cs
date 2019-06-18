using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ExperienciaLaboralInternaDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public int idTipoContrato { get; set; }
        public int idArea { get; set; }
        public int idProgramaEducativo { get; set; }
        public int idPeriodo { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public string strActividadDesempeñada { get; set; }
    }
}
