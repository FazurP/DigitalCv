﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ProyectoInvestigacionDomainModel
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idStatus { get; set; }
        public int idPersonal { get; set; }
        public DocumentosDomainModel documentosDMReseña { get; set; }
        public DocumentosDomainModel documentosDMResumen { get; set; }
        public string strTituloProyecto { get; set; }
        public string strNombrePatrocinador { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public string strTipoPatrocinador { get; set; }
        public string strInvestigadoresParticipantes { get; set; }
        public string strAlumnosParticipantes { get; set; }
        public string strActividadesRealizadas { get; set; }
        public string strConvocatoria { get; set; }
        public bool bitProyectoTecnologico { get; set; }
        public bool bitConsideraCurriculum { get; set; }
    }
}