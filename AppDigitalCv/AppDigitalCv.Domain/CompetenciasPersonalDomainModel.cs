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
        public int idCompetencia { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaRegistro { get; set; }

    }
}
