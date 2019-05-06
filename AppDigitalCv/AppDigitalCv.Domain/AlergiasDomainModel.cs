using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class AlergiasDomainModel
    {
        public int IdAlergiasPersonal { get; set; }

        public int IdAlergia { get; set; }

        public int IdPersonal { get; set; }

        public DateTime dteFechaRegistro {get;set;}
    }
}
