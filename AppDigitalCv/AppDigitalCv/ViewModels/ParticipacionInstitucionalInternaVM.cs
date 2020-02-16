using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ParticipacionInstitucionalInternaVM
    {
        public int id { get; set; }
        public int idCatProgramaEducativo { get; set; }
        public int idPersonal { get; set; }
        public int idCatDocumento { get; set; }
        public int idCatTipoActividad { get; set; }
        public string strActividad { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
        public DocumentosVM documentos { get; set; }

    }
}