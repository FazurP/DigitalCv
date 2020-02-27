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

        //Objetos de las relaciones.

        public InstitucionAcreditaBachilleratoVM InstitucionAcreditaBachillerato { get; set; }
    }
}