using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ParticipacionDocenteDomainModel
    {
        public int Id { get; set; }
        public int IdCatDocumento { get; set; }
        public int IdPersonal { get; set; }
        public string StrEvento { get; set; }
        public string StrTipoEvento { get; set; }
        public string StrParticipacion { get; set; }
        public string StrTipoParticipacion { get; set; }
        public bool BitPonencia { get; set; }
        public string StrNombrePonencia { get; set; }
        public string StrNombreInstitucionEmpresa { get; set; }
        public string StrLugar { get; set; }
        public string DteFecha { get; set; }

        public virtual DocumentosDomainModel CatDocumentosDM { get; set; }
        public virtual PersonalDomainModel PersonalDM { get; set; }
    }
}
