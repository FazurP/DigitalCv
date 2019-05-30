using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class SolicitudEmpleoDomainModel
    {
        public virtual DocumentosDomainModel DocumentosDM { get; set; }
        public string strIdentificador { get; set; }
    }
}
