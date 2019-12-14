using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas09DomainModel
    {
        public int id { get; set; }
        public bool bitLesion { get; set; }
        public int idHuesos { get; set; }
        public int idLigamentos { get; set; }
        public int idArticulaciones { get; set; }

        //Objetos de las relaciones

        public LesionHuesosDomainModel LesionHuesos { get; set; }
        public LesionLigamentosDomainModel LesionLigamentos { get; set; }
        public LesionArticulacionesDomainModel LesionArticulaciones { get; set; }
    }
}
