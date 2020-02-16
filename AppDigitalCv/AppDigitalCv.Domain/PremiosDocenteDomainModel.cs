using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class PremiosDocenteDomainModel
    {
        public int id { get; set; }
        public int IdPersonal { get; set; }
        public int IdDocumento { get; set; }
        public string DteFechaObtencionPremio { get; set; }
        public string StrInstitucion { get; set; }
        public string StrNombrePremio { get; set; }
        public string StrActividadDesempeniada { get; set; }
        public virtual DocumentosDomainModel Documentos { get; set; }
    }
}
