﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class FamiliaresDomainModel
    {
        public virtual FamiliarDomainModel PadreDomainModel { get; set; }
        public virtual FamiliarDomainModel MadreDomainModel { get; set; }
        public virtual FamiliarDomainModel ParejaDomainModel { get; set; }
    }
}
