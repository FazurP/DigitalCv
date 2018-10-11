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
        public string strNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string strCurp { get; set; }
        public string strRfc { get; set; }
        public string archivoRfc { get; set; }
        public string strHomoclave { get; set; }
        public System.DateTime dteFechaNacimiento { get; set; }
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
