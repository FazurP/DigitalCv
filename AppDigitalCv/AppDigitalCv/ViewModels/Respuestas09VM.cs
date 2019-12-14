using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas09VM
    {
        public int id { get; set; }
        public bool bitLesion { get; set; }
        public int idHuesos { get; set; }
        public int idLigamentos { get; set; }
        public int idArticulaciones { get; set; }

        //Objetos de las relaciones
        
        public LesionHuesosVM LesionHuesos { get; set; }
        public LesionLigamentosVM LesionLigamentos { get; set; }
        public LesionArticulacionesVM LesionArticulaciones { get; set; }
    }
}