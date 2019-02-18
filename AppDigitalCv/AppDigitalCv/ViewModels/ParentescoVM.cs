using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ParentescoVM
    {
        [Key]
        public int IdFamiliar { get; set; }

        [Required(ErrorMessage = "El Nombre del Familiar es Requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingresa solo caracteres validos")]
        public string StrNombre { get; set; }

        public string StrOcupacion { get; set; }
        public string StrDomicilio { get; set; }

        [Required(ErrorMessage = "La Edad es Requerida")]
        //[RegularExpression("^/d+$", ErrorMessage = "Ingresa solo caracteres validos")]
        public int IntEdad { get; set; }

        public bool BitVive { get; set; }

        //[RegularExpression("/^([0][1-9]|[12][0-9]|3[01])(\\/|-)([0][1-9]|[1][0-2])\\2(\\d{4})$/", ErrorMessage = "Ingresa solo caracteres validos")]
        public string DteFechaNacimiento { get; set; }

        public int IdParentesco { get; set; }
        public virtual ICollection<PersonalVM> PersonalVm { get; set; }
        public int IdPersonal { get; set; }
    }
}