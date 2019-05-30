using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DocumentacionPersonalDomainModel
    {
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public virtual NumeroLicenciaManejoDomainModel NumeroLicenciaManejoDM { get; set; }
        public virtual NumeroCartillaMilitarDomainModel NumeroCartillaMilitarDM { get; set; }
        public virtual NumeroPasaporteDomainModel NumeroPasaporteDM { get; set; }
        public virtual NumeroSeguridadSocialDomainModel NumeroSeguridadSocialDM { get; set; }
        public virtual NumeroVisaCanadaDomainModel NumeroVisaCanadaDM { get; set; }
        public virtual NumeroVisaUsaDomainModel NumeroVisaUsaDM { get; set; }
        public virtual RegistroProfEstatalDomainModel RegistroProfEstatalDM { get; set; }
        //public string strIdentificador { get; set; }
        //public virtual DocumentosDomainModel DocumentosDM { get; set; }
        public virtual IfeDomainModel IfeDM { get; set; }
        public virtual ComprobanteDomicilioDomainModel ComprobanteDomicilioDM { get; set; }
        public virtual SolicitudEmpleoDomainModel SolicitudEmpleoDM { get; set; }
    }
}