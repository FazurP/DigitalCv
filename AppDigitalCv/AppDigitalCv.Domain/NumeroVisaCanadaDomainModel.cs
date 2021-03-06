﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class NumeroVisaCanadaDomainModel
    {
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public string strNumeroDocumento { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public virtual DocumentosDomainModel DocumentosDM { get; set; }
        public string strIdentificador { get; set; }
    }
}
