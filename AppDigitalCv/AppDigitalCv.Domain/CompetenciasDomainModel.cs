using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CompetenciasDomainModel
    {
        public int idCompetencia { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public string strTipo { get; set; }
        public bool isChecked { get; set; }
    }
}
