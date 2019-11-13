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
        public string NombreFacebook { get; set; }
        public string NombreTwitter { get; set; }
        public int IdPersonal { get; set; }
        public int IdTelefono { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoRecados { get; set; }
        public string strNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string strDireccion { get; set; }
        public bool bitContactoEmergencia { get; set; }

    }
}
