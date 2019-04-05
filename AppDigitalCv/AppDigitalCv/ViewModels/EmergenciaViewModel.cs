using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EmergenciaViewModel
    {
        public int IdEmergencia { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string StrNombre { get; set; }

        [Required(ErrorMessage = "El Telefono es Obligatorio")]
        public string StrTelefono { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9.# ]+$")]
        [Required(ErrorMessage = "La Direccion es Obligatoria")]
        public string StrDireccion { get; set; }

        [Required(ErrorMessage = "El Parentesco es Obligatorio")]
        public int IdParentesco { get; set; }
        public int IdPersonal { get; set; }
        //public PersonalVM PersonalVM { get; set; }


    }
}