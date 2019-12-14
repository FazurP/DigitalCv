using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas07VM
    {
        public int id { get; set; }
        public bool bitPadecido { get; set; }
        public int idEnfermedadExantematica { get; set; }

        //Objetos de la relacion

        public EnfermedadesExantematicaVM EnfermedadesExantematica { get; set; }
    }
}