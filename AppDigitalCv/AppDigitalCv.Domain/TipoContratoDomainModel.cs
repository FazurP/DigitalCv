using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class TipoContratoDomainModel
    {
        public int idTipoContrato { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public int idSalario { get; set; }
        public int idCategoria { get; set; }
    }
}
