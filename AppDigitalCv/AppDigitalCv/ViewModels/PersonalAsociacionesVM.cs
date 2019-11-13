using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PersonalAsociacionesVM
    {
        public int IdPersonal { get; set; }
        public int IdAsociacion { get; set; }

        [Required(ErrorMessage ="Este Campo es Requerido")]
        [DataType(DataType.Date)]
        public string DteFecha { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string StrTipoParticipacion { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(70)]
        [DataType(DataType.Text)]
        public string strOrganizacionPertenece { get; set; }


        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(170)]
        [DataType(DataType.Text)]
        public string strFuncionDesempeñada { get; set; }

        public virtual PersonalVM PersonalVM { get; set; }
        public virtual AsociacionesVM AsociacionesVM { get; set; }
    }
}