﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ParticipacionInstitucionalExternaDomainModel
    {
        public int id { get; set; }
        public int idCatInstitucionSuperior { get;set; }
        public int idCatDocumento { get; set; }
        public int idPersonal { get; set; }
        public string strActividad { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaTermino { get; set; }
        public DocumentosDomainModel documentos { get; set; }


    }
}
