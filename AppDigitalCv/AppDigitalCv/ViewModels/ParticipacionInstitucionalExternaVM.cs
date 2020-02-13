using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppDigitalCv.ViewModels
{
    public class ParticipacionInstitucionalExternaVM
    {
        public int id { get; set; }
        public int idCatInstitucionSuperior { get; set; }
        public int idCatDocumento { get; set; }
        public int idPersonal { get; set; }
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ., ]+$")]
        public string strActividad { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public DocumentosVM documentos { get; set; }


    }
}