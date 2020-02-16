using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DeportePersonalDomainModel
    {
        public int IdDeportePersonal { get; set; }
        public string FechaRegistro { get; set; }
        public FrecuenciaDomainModel Frecuencia { get; set; }
        public int IdPersonal { get; set; }
        public int IdDeporte { get; set; }
        public int IdFrecuencia { get; set; }
        public string strHorasPractica { get; set; }
        public DeporteDomainModel Deporte { get; set; }
    }
}
