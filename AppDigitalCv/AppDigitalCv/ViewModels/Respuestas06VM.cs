using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Respuestas06VM
    {
        public int id { get; set; }
        public bool bitAlergico { get; set; }
        public int idMedicamento { get; set; }
        public int idSustancia { get; set; }
        public int idAlimento { get; set; }

        //Objetos de las relaciones

        public AlergiaMedicamentoVM AlergiaMedicamento { get; set; }
        public AlergiaSustanciaVM AlergiaSustancia { get; set; }
        public AlergiaAlimentoVM AlergiaAlimento { get; set; }
    }
}