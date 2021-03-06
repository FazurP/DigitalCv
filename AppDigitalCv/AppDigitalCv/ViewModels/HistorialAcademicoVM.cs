﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class HistorialAcademicoVM
    {
        public string strNombre { get; set; }
        public int InstitucionAcredita { get; set; }
        public int Status { get; set; }
        public bool bitReconocimientePNPC { get; set; }
        public int FuenteFinanciamiento { get; set; }
        public DoctoradoVM Doctorado { get; set; }
        public MaestriaVM Maestria { get; set; }
        public LicenciaturaIngenieriaVM LicenciaturaIngenieria { get; set; }
        public BachilleratoVM Bachillerato { get; set; }
        public DocumentosVM Documentos { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public string strInstitucionAcredita { get; set; }
        public HttpPostedFileWrapper[] DocumentosPosted { get; set; }
        //Distribuidores

        public int Type { get; set; }
    }
}