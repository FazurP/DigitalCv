using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CapacitacionCompetenciasProfesionalesDomainModel
    {
        public int id { get; set; }
        public int idCapacitacionCompetenciasProfesionales { get; set; }
        public string strNombreDiplomadoCursoTaller { get; set; }
        public string strNumeroHoras { get; set; }
        public int idInstitucionAcreditaCapacitacionProfesional { get; set; }
        public int idPersonal { get; set; }
    }
}
