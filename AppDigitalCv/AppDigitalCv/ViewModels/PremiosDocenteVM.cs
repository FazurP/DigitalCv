using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PremiosDocenteVM
    {
        public int IdPersonal { get; set; }
        public int IdDocumento { get; set; }
        public string DteFechaObtencionPremio { get; set; }
        public string StrInstitucion { get; set; }
        public string StrNombrePremio { get; set; }
        public string StrActividadDesempeniada { get; set; }
        public string DteFechaInicioPremio { get; set; }
        public string DteFechaFinPremio { get; set; }
        public string StrTipoPremio { get; set; }
        public virtual PersonalVM PersonalVM { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }
    }
}