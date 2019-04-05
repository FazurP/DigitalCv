using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DatosContactoVM
    {
        
        public int IdDatosContacto { get; set; }

        public int IdPersonal { get; set; }

        public int IdTelefono { get; set; }

        [RegularExpression("[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net){1}")]
        [Required(ErrorMessage ="El Correo Personal es Obligatorio")]
        public string MailPersonal { set; get; }

        [RegularExpression("[a-zA-Z0-9._-]{3,25}[@]{1}(uttt){1}[.]{1}(edu){1}[.]{1}(mx){1}")]
        [Required(ErrorMessage = "El Correo Institucional es Obligatorio")]
        public string MailInstitucional { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "El Usuario de Facebook es Obligatorio")]
        public string NombreFacebook { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "El Usuario de Twitter es Obligatorio")]
        public string NombreTwitter { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage = "El Telefono de Casa es Obligatorio")]
        public string TelefonoCasa { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage ="El Telefono Celular es Obligatorio")]
        public string TelefonoCelular { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage ="El Telefono de Recados es Obligatorio")]
        public string TelefonoRecados { get; set; }

    }
}