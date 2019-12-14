using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas04VM
    {
        public int id { get; set; }
        public int idOpcion { get; set; }

        //Objetos de las relaciones

        public OpcionesRespuesta04VM OpcionesRespuesta04 { get; set; }
    }
}