﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ProyectoInvestigacionVM
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public DocumentosVM documentos { get; set; }
        public string strTituloProyecto { get; set; }
        public string strNombrePatrocinador { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaTermino { get; set; }
        public string strTipoPatrocinador { get; set; }
        public string strInvestigadoresParticipantes { get; set; }
        public string strAlumnosParticipantes { get; set; }
        public string strActividadesRealizadas { get; set; }
        public string strConvocatoria { get; set; }
        public bool bitProyectoTecnologico { get; set; }

    }
}