using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas12DomainModel
    {
        public int id { get; set; }
        public bool bitPadece { get; set; }
        public int idEnfermedades { get; set; }

        //Objetos de las relaciones

        public EnfermedadesDomainModel Enfermedades { get; set; }
    }
}
