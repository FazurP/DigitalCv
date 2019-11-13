﻿using System;
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
        public string DteFecha { get; set; }
        public string StrTipoParticipacion { get; set; }
        public string strOrganizacionPertenece { get; set; }
        public string strFuncionDesempeñada { get; set; }

        public virtual PersonalDomainModel PersonalDomainModel{get;set;}
        public virtual AsociacionesDomainModel AsociacionesDomainModel { get; set; }
        
    }
}
