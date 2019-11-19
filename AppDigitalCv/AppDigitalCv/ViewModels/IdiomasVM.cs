﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class IdiomasVM
    {
        public int id { get; set; }
        public int idIdioma { get; set; }
        public int idNivelConocimiento { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }

        public DocumentosVM documentosVM { get; set; }
        public IdiomaVM idiomaVM { get; set; }
        public NivelConocimientoVM nivelConocimientoVM {get;set;}
    }
}