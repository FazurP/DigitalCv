using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas04DomainModel
    {
        public int id { get; set; }
        public int idOpcion { get; set; }

        //Objetos de las relaciones

        public OpcionesRespuesta04DomainModel OpcionesRespuesta { get; set; }
    }
}
