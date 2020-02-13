using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ParticipacionInstitucionalInternaDomainModel
    {
        public int id { get; set; }
        public int idCatProgramaEducativo { get; set; }
        public int idPersonal { get; set; }
        public int idCatDocumento { get; set; }
        public int idCatTipoActividad { get; set; }
        public string strActividad { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public DocumentosDomainModel documentos { get; set; }
    }
}
