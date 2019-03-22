using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PasatiempoVM
    {
        public int IdPasatiempo { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public Nullable<int> IdPersonal { get; set; }
    }
}