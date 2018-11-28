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

        [Required(ErrorMessage ="El Correo Personal es Obligatorio")]
        public string MailPersonal { set; get; }

        [Required(ErrorMessage = "El Correo Institucional es Obligatorio")]
        public string MailInstitucional { get; set; }

        public string NombreFacebook { get; set; }

        public string NombreTwitter { get; set; }

        [Required(ErrorMessage = "El Telefono de Casa es Obligatorio")]
        public string TelefonoCasa { get; set; }

        [Required(ErrorMessage ="El Telefono Celular es Obligatorio")]
        public string TelefonoCelular { get; set; }

        public string TelefonoRecados { get; set; }

    }
}