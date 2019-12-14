using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class EncuestaDomainModel
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

        //Objetos de las relaciones

        public Respuestas01DomainModel Respuestas01 { get; set; }
        public Respuestas02DomainModel Respuestas02 { get; set; }
        public Respuestas03DomainModel Respuestas03 { get; set; }
        public Respuestas04DomainModel Respuestas04 { get; set; }
        public Respuestas05DomainModel Respuestas05 { get; set; }
        public Respuestas06DomainModel Respuestas06 { get; set; }
        public Respuestas07DomainModel Respuestas07 { get; set; }
        public Respuestas08DomainModel Respuestas08 { get; set; }
        public Respuestas09DomainModel Respuestas09 { get; set; }
        public Respuestas10DomainModel Respuestas10 { get; set; }
        public Respuestas11DomainModel Respuestas11 { get; set; }
        public Respuestas12DomainModel Respuestas12 { get; set; }
        public Respuestas13DomainModel Respuestas13 { get; set; }
        public Respuestas14DomainModel Respuestas14 { get; set; }
        public Respuestas15DomainModel Respuestas15 { get; set; }
        public Respuestas16DomainModel Respuestas16 { get; set; }
        public Respuestas17DomainModel Respuestas17 { get; set; }
    }
}
