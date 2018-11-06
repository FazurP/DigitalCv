using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class PersonalDomainModel
    {
        public int idPersonal { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string Homoclave { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string strLogros { get; set; }
        public string strUrlFoto { get; set; }
        public string strUrlCurp { get; set; }
        public string strUrlRfc { get; set; }
        public string strGenero { get; set; }
        public int idEstadoCivil { get; set; }
        public int idUsuario { get; set; }
        public int idTipoSangre { get; set; }
        public int idDireccion { get; set; }
        public int idFamiliar { get; set; }
        
    }
}
