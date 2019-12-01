using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class LenguasDomainModel
    {
        public int id { get; set; }
        public int idLengua { get; set; }
        public int idPersonal { get; set; }
        public string strEscritura { get; set; }
        public string strLectura { get; set; }
        public string strEntendimiento { get; set; }
        public string strComunicacion { get; set; }

        public DialectoDomainModel DialectoDomainModel { get; set; }
    }
}
