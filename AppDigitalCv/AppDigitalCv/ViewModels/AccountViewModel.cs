using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppDigitalCv.ViewModels
{
    public class AccountViewModel
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string NombreCompleto { get; set; }

        [Required(ErrorMessage ="El email es obligatorio")]
        public string Email { get; set; }

        public string ImgUserUrl { get; set; }

        [Required(ErrorMessage ="El Password es obligatorio")]
        public string Password { get; set; }

        public int IdPersonal { get; set; }
    }
}