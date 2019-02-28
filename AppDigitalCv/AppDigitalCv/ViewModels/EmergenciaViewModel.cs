using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EmergenciaViewModel
    {
        public int IdEmergencia { get; set; }
        public string StrNombre { get; set; }
        public string StrTelefono { get; set; }
        public string StrDireccion { get; set; }
        public int IdParentesco { get; set; }
        public int IdPersonal { get; set; }
        //public PersonalVM PersonalVM { get; set; }


    }
}