using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class Respuestas06DomainModel
    {
        public int id { get; set; }
        public bool bitAlergico { get; set; }
        public int idMedicamento { get; set; }
        public int idSustancia { get; set; }
        public int idAlimento { get; set; }

        //Objetos de la relaciones

        public AlergiaMedicamentoDomainModel AlergiaMedicamento { get; set; }
        public AlergiaSustanciaDomainModel AlergiaSustancia { get; set; }
        public AlergiaAlimentoDomainModel AlergiaAlimento { get; set; }
    }
}
