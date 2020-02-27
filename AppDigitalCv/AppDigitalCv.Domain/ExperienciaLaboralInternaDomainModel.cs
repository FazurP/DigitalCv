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
        public int idArea { get; set; }
        public int idPeriodo { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaTermino { get; set; }
        public string strActividadDesempeñada { get; set; }
        public string strTipoProfesor { get; set; }
        public bool bitPuestoActual { get; set; }

        //Objetos de las relaciones

        public ProgramaEducativoDomainModel ProgramaEducativo { get; set; }
        public AreaDomainModel Area { get; set; }
    }
}
