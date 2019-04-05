using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PremiosDocenteVM
    {
        public int IdPersonal { get; set; }
        public int IdDocumento { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public string DteFechaObtencionPremio { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "El Nombre de la Institucion es Obligatorio")]
        public string StrInstitucion { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9 ]+$")]
        [Required(ErrorMessage = "El Nombre del Premio es Obligatorio")]
        public string StrNombrePremio { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9 ]+$")]
        [Required(ErrorMessage = "El Nombre de la Actividad Desempeñada es Obligatoria")]
        public string StrActividadDesempeniada { get; set; }

        [Required(ErrorMessage ="La Fecha es Obligatoria")]
        public string DteFechaInicioPremio { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public string DteFechaFinPremio { get; set; }

        public string StrTipoPremio { get; set; }
        public virtual PersonalVM PersonalVM { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }
    }
}