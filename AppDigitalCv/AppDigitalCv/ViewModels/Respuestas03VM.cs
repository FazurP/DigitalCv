using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas03VM
    {
        public int id { get; set; }
        public bool bitFumador { get; set; }
        public int idFumador { get; set; }

        //Objetos de las relaciones

        public FumadorVM Fumador { get; set; }

    }
}