using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CompetenciasTiDomainModel
    {
        public int IdCompetenciaTIPersonal { get; set; }
        public int IdCompetenciaTI { get; set; }
        public int IdPersonal { get; set; }
        public Nullable<System.DateTime> DteFechaRegistro { get; set; }

        public virtual CompetenciaTiDomainModel CompetenciaTiDomainModel   { get; set; }
        public virtual PersonalDomainModel PersonalDomainModel { set; get; }
        
    }
}
