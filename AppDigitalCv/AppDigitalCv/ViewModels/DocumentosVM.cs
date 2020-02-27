using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DocumentosVM
    {
        public int IdDocumento { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public string StrUrl { get; set; }
        //public virtual ICollection<PremiosDocenteVM> PremiosDocenteVM { get; set; }
        [Required(ErrorMessage = "El archivo es obligatorio")]
        public HttpPostedFileWrapper DocumentoFile { get; set; }
        //public HttpPostedFileWrapper[] DocumentosFiles { get; set; }
        public virtual DocumentacionPersonalVM DocumentacionPersonalVMs { get; set; }

    }
}