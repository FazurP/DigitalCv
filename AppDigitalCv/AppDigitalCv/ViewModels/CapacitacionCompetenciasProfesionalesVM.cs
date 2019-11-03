using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CapacitacionCompetenciasProfesionalesVM
    {
        public int id { get; set; }
        public int idCapacitacionCompetenciasProfesionales { get; set; }
        public string strNombreDiplomadoCursoTaller { get; set; }
        public string strNumeroHoras { get; set; }
        public int idInstitucionAcreditaCapacitacionProfesional { get; set; }
        public int idPersonal { get; set; }
    }
}