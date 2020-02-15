using AppDigitalCv.Domain;
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

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingresa solo caracteres validos")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string StrNombre { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string strApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string strApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string StrOcupacion { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string StrDomicilio { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        public bool BitVive { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DataType(DataType.Date)]
        public string DteFechaNacimiento { get; set; }

        public int IdParentesco { get; set; }
        public virtual ICollection<PersonalVM> PersonalVm { get; set; }
        public int IdPersonal { get; set; }

        //Objetos de las relaciones

        public ParentescoDomainModel Parentesco { get; set; }
    }
}