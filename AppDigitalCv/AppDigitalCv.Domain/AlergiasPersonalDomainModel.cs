using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class AlergiasPersonalDomainModel
    {

        public int idAlergiasPersonal { get; set; }
        public int idAlergia { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaRegistro { get; set; }

    }
}
