using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DocumentosProfesionalesVM
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idDoctorado { get; set; }
        public int idMaestria { get; set; }
        public int idLicenciaturaIng { get; set; }
        public DoctoradoVM Doctorado { get; set; }
        public MaestriaVM Maestria { get; set; }
        public LicenciaturaIngenieriaVM LicenciaturaIngenieria { get; set; }
    }
}