using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ManualOperacionDomainModel
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idStatus { get; set; }
        public int idPersonal { get; set; }
        public string strNombre { get; set; }
        public string strDescripcion { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public DateTime dteFechaPublicacion { get; set; }

    }
}
