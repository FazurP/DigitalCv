using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas11VM
    {
        public int id { get; set; }
        public bool bitRealizaActividadFisica { get; set; }
        public int idActividades { get; set; }

        //Objetos de las relaciones

        public ActividadesFisicasVM ActividadesFisicas { get; set; }
    }
}