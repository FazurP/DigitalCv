﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DeportePersonalVM
    {
        public int IdDeportePersonal {get;set;}
        public string FechaRegistro { get; set; }
        public FrecuenciaVM Frecuencia { get; set; }
        public int IdPersonal { get; set; }
        public int IdDeporte { get; set; }
        public int IdFrecuencia { get; set; }
        public string strHorasPractica { get; set; }
        public DeporteVM Deporte { get; set; }

    }
}