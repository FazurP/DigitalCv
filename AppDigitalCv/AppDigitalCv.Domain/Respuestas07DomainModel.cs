using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas07DomainModel
    {
        public int id { get; set; }
        public bool bitPadecido { get; set; }
        public int idEnfermedadesExantematica { get; set; }

        //Objetos de las relaciones

        public EnfermedadesExantematicaDomainModel EnfermedadesExantematica { get; set; }
    }
}
