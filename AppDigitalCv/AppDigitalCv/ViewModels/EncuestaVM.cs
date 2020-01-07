using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EncuestaVM
    {
        public int id { get; set; }
        public int idRespuesta01 { get; set; }
        public int idRespuesta02 { get; set; }
        public int idRespuesta03 { get; set; }
        public int idRespuesta04 { get; set; }
        public int idRespuesta05 { get; set; }
        public int idRespuesta06 { get; set; }
        public int idRespuesta07 { get; set; }
        public int idRespuesta08 { get; set; }
        public int idRespuesta09 { get; set; }
        public int idRespuesta10 { get; set; }
        public int idRespuesta11 { get; set; }
        public int idRespuesta12 { get; set; }
        public int idRespuesta13 { get; set; }
        public int idRespuesta14 { get; set; }
        public int idRespuesta15 { get; set; }
        public int idRespuesta16 { get; set; }
        public int idRespuesta17 { get; set; }
        public string dteFechaRealizo { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public Respuestas01VM Respuestas01 { get; set; }
        public Respuestas02VM Respuestas02 { get; set; }
        public Respuestas03VM Respuestas03 { get; set; }
        public Respuestas04VM Respuestas04 { get; set; }
        public Respuestas05VM Respuestas05 { get; set; }
        public Respuestas06VM Respuestas06 { get; set; }
        public Respuestas07VM Respuestas07 { get; set; }
        public Respuestas08VM Respuestas08 { get; set; }
        public Respuestas09VM Respuestas09 { get; set; }
        public Respuestas10VM Respuestas10 { get; set; }
        public Respuestas11VM Respuestas11 { get; set; }
        public Respuestas12VM Respuestas12 { get; set; }
        public Respuestas13VM Respuestas13 { get; set; }
        public Respuestas14VM Respuestas14 { get; set; }
        public Respuestas15VM Respuestas15 { get; set; }
        public Respuestas16VM Respuestas16 { get; set; }
        public Respuestas17VM Respuestas17 { get; set; }

    }
}