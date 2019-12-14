using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas12VM
    {
        public int id { get; set; }
        public bool bitPadece { get; set; }
        public int idEnfermedades { get; set; }

        //Objetos de las relaciones

        public EnfermedadesVM Enfermedades { get; set; }
    }
}