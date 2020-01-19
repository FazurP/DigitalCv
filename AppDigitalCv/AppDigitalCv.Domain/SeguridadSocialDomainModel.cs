using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class SeguridadSocialDomainModel
    {
        public int id { get; set; }
        public int idInstitucion { get; set; }
        public string strNumero { get; set; }

        //Objetos de las relaciones

        public InstitucionesSaludDomainModel InstitucionesSalud { get; set; }
    }
}
