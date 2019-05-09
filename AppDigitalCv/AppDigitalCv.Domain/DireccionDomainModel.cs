using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DireccionDomainModel
    {
        public int IdDireccion { get; set; }
        public string StrCalle { get; set; }
        public string StrNumeroInterior { get; set; }
        public string StrNumeroExterior { get; set; }
        public int IdColonia { get; set; }
        //este atributo se establece para indentificar el nombre de 
        //la colonia en una consulta
        public string NombreColonia { get; set; }
    }
}
