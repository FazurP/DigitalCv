using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class NumeroLicenciaManejoVM
    {
        public string strNumeroDocumento { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }
        public string strIdentificador { get; set; }
    }
}