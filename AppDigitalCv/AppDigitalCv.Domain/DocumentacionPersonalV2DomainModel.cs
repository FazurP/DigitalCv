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
        public int idTipoDocumento { get; set; }
        public string dteExpedicion { get; set; }
        public string dteVigenciaDocumento { get; set; }
        public virtual DocumentosDomainModel Documentos { get; set; }
    }
}
