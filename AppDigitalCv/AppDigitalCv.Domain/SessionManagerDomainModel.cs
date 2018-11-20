using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class SessionManagerDomainModel
    {
        public int IdPersonal { get; set; }

        public string Nombre { get; set; }

        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string ImgUserUrl { get; set; }

        public string Password { get; set; }
    }
}
