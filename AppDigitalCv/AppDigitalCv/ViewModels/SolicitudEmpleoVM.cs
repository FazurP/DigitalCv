using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class SolicitudEmpleoVM
    {
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }
        public string strIdentificador { get; set; }
    }
}