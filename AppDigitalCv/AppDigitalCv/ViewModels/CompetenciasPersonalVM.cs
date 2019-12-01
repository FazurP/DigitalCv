using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CompetenciasPersonalVM
    {
        public int idCompetenciasConocimientosPersonal { get; set; }
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public DateTime dteFechaRegistro { get; set; }
        public DocumentosVM file { get; set; }
    }
}