using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DocumentacionPersonalV2DomainModel
    {
        public int idPesonal { get; set; }
        public int idDocumento { get; set; }
        public string strNumeroDocumento { get; set; }
        public DateTime dteExpedicion { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public string strIdentificador { get; set; }
        public virtual DocumentosDomainModel DocumentosDomainModel { get; set; }
    }
}
