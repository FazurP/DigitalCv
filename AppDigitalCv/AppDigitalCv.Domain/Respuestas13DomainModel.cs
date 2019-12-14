using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas13DomainModel
    {
        public int id { get; set; }
        public bool bitTratamiento { get; set; }
        public int idTratamiento { get; set; }

        //Objetos de las relaciones

        public TratamientoDomainModel Tratamiento { get; set; }
    }
}
