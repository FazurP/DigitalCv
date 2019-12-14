using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas03DomainModel
    {
        public int id { get; set; }
        public bool bitFumador { get; set; }
        public int idFumador { get; set; }

        //Objetos de las relaciones

        public FumadorDomainModel Fumador { get; set; }
    }
}
