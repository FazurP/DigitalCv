using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DireccionDomainModel
    {

        //catDireccion
        public int idDireccion { get; set; }
        public string strCalle { get; set; }
        public string strNumeroInterior { get; set; }
        public string strNumeroExterior { get; set; }
        public int idColonia { get; set; }

    }
}
