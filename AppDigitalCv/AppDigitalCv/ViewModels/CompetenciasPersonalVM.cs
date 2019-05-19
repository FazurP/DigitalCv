using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CompetenciasPersonalVM
    {
        public int idCompetenciasConocimientosPersonal { get; set; }
        public int idCompetencia { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaRegistro { get; set; }
    }
}