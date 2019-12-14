using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas11DomainModel
    {
        public int id { get; set; }
        public bool bitRealizaActividadFisica { get; set; }
        public int idActividad { get; set; }

        //Objetos de las relaciones

        public ActividadesFisicasDomainModel ActividadesFisicas { get; set; }
    }
}
