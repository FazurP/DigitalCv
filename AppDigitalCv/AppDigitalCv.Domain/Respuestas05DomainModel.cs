using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas05DomainModel
    {
        public int id { get; set; }
        public int idRh { get; set; }
        public int idGrupoSanguineo { get; set; }

        //Objetos de las relaciones 

        public RhDomainModel Rh { get; set; }
        public GrupoSanguineoDomainModel GrupoSanguineo { get; set; }
    }
}
