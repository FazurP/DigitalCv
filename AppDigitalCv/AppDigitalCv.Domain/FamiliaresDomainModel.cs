﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class FamiliaresDomainModel
    {
        public FamiliarDomainModel PadreDomainModel { get; set; }
        public FamiliarDomainModel MadreDomainModel { get; set; }
        public FamiliarDomainModel ParejaDomainModel { get; set; }
    }
}
