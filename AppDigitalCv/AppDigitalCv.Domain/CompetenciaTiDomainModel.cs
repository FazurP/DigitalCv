using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CompetenciaTiDomainModel
    {
        public int IdCompetenciaTI { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public bool isChecked { get; set; }
    }
}
