using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DeportePersonalVM
    {
        public int IdDeportePersonal {get;set;}
        public string FechaRegistro { get; set; }
        public FrecuenciaVM FrecuenciaVM { get; set; }
        public int IdPersonal { get; set; }
        public int IdDeporte { get; set; }
        public int IdFrecuencia { get; set; }
        public DeporteVM DeporteVM { get; set; }
        public PasatiempoVM PasatiempoVM { get; set; }

    }
}