using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas05VM
    {
        public int id { get; set; }
        public int idRh { get; set; }
        public int idGrupoSanguineo { get; set; }

        //Objetos de las relaciones

        public RhVM Rh { get; set; }
        public GrupoSanguineoVM GrupoSanguineo { get; set; }
    }
}