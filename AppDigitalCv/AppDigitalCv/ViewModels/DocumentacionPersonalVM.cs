using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DocumentacionPersonalVM
    {
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public virtual NumeroLicenciaManejoVM NumeroLicenciaManejoVM { get; set; }
        public virtual NumeroCartillaMilitarVM NumeroCartillaMilitarVM { get; set; }
        public virtual NumeroPasaporteVM NumeroPasaporteVM { get; set; }
        public virtual NumeroSeguridadSocialVM NumeroSeguridadSocialVM { get; set; }
        public virtual NumeroVisaCanadaVM NumeroVisaCanadaVM { get; set; }
        public virtual NumeroVisaUsaVM NumeroVisaUsaVM { get; set; }
        public virtual RegistroProfEstatalVM RegistroProfEstatalVM { get; set; }
        public string strIdentificador { get; set; }
        public string strNumeroDocumento { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public virtual IfeVM IfeVM { get; set; }
        public virtual ComprobanteDomicilioVM ComprobanteDomicilioVM { get; set; }
        public virtual SolicitudEmpleoVM SolicitudEmpleoVM { get; set; }
    }
}