using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class BachilleratoVM
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaBachillerato { get; set; }
        public int idDocumento { get; set; }

        //Objetos de las relaciones.

        public DocumentosVM Documentos { get; set; }
        public InstitucionAcreditaBachilleratoVM InstitucionAcreditaBachillerato { get; set; }
    }
}