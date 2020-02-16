using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PremiosDocenteVM
    {
        public int id { get; set; }
        public int IdPersonal { get; set; }
        public int IdDocumento { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatoria")]
        public string DteFechaObtencionPremio { get; set; }

        [Required(ErrorMessage = "El Nombre de la Institucion es Obligatorio")]
        public string StrInstitucion { get; set; }

        [Required(ErrorMessage = "El Nombre del Premio es Obligatorio")]
        public string StrNombrePremio { get; set; }

        [Required(ErrorMessage = "El Nombre de la Actividad Desempeñada es Obligatoria")]
        public string StrActividadDesempeniada { get; set; }
        public virtual DocumentosVM Documentos { get; set; }
    }
}