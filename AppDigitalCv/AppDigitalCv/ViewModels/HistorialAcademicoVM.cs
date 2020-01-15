using System;
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
        public bool PNPC { get; set; }
        public int FuenteFinanciamiento { get; set; }
        public LicenciaturaIngenieriaVM LicenciaturaIngenieria { get; set; }
        public BachilleratoVM Bachillerato { get; set; }
        public DocumentosVM Documentos { get; set; }

        //Distribuidores

        public int Type { get; set; }
    }
}