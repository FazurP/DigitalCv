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
        public int StrEvento { get; set; }
        public int StrTipoEvento { get; set; }
        public int StrParticipacion { get; set; }
        public int StrTipoParticipacion { get; set; }
        public bool BitPonencia { get; set; }
        public string StrNombrePonencia { get; set; }
        public string StrNombreInstitucionEmpresa { get; set; }
        public string StrLugar { get; set; }
        public int DteFecha { get; set; }


    }
}
