using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DatosContactoDomainModel
    {
        public int IdDatosContacto { get; set; }

        public string MailPersonal { set; get; }

        public string MailInstitucional { get; set; }

        public string NombreFacebook { get; set; }

        public string NombreTwitter { get; set; }

        public int IdPersonal { get; set; }

        public string TelefonoCasa { get; set; }

        public string TelefonoCelular { get; set; }

        public string TelefonoRecados { get; set; }

        public int IdTelefono { get; set; }
    }
}
