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

        public string MailPersonal { set; get; }

        public string MailInstitucional { get; set; }

        public string NombreFacebook { get; set; }

        public string NombreTwitter { get; set; }

        public int IdPersonal { get; set; }
        
        public string TelefonoCasa { get; set; }

        public string TelefonoCelular { get; set; }

        public string Telefonorecados { get; set; }

    }
}