using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas13VM
    {
        public int id { get; set; }
        public bool bitTratamiento { get; set; }
        public int idTratamiento { get; set; }

        //Objetos de las relaciones

        public TratamientoVM Tratamiento { get; set; }
    }
}