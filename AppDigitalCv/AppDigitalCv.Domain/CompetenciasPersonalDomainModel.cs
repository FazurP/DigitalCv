using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CompetenciasPersonalDomainModel
    {
        public int idCompetenciasConocimientosPersonal { get; set; }   
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public DateTime dteFechaRegistro { get; set; }
        public DocumentosDomainModel file { get; set; }

        public string dteFechaRegistroString { get; set; }


    }
}
