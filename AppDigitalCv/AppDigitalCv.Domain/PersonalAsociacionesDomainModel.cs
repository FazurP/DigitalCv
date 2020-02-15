using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class PersonalAsociacionesDomainModel
    {
        public int IdPersonal { get; set; }
        public int IdAsociacion { get; set; }
        public DateTime DteFecha { get; set; }
        public string StrTipoParticipacion { get; set; }
        public string strFuncionDesempeñada { get; set; }

        public virtual PersonalDomainModel PersonalDomainModel{get;set;}
        public virtual AsociacionesDomainModel Asociaciones { get; set; }
        
    }
}
