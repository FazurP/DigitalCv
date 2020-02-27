using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class LicenciaturaIngenieriaVM
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcredita { get; set; }
        public int idStatusLicenciatura { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones.

        public InstitucionAcreditaLicenciaturaVM InstitucionAcreditaLicenciatura { get; set; }
        public StatusLicenciaturaVM StatusLicenciatura { get; set; }
    }
}