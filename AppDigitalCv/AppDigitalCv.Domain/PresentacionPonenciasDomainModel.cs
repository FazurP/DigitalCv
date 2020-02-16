using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class PresentacionPonenciasDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public string strNombre { get; set; }
        public string strLugarInstitucionPresento { get; set; }
        public string strAño { get; set; }
    }
}
