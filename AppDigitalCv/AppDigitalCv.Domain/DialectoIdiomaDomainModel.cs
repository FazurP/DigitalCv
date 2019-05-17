using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DialectoIdiomaDomainModel
    {
        public int IdIdiomaDialectoPersonal { get; set; }
        public Nullable<int> IdIdioma { get; set; }
        public Nullable<int> IdDialecto { get; set; }
        public int IdPersonal { get; set; }
        public string StrComunicacionPorcentaje { get; set; }
        public string StrEscrituraProcentaje { get; set; }
        public string StrEntendimientoPorcentaje { get; set; }
        public string StrLecturaPorcentaje { get; set; }
        public Nullable<System.DateTime> dteFechaRegistro { get; set; }
    }
}
