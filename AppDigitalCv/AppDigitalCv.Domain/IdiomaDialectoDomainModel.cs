using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class IdiomaDialectoDomainModel
    {
        public int idIdiomaDialectoPersonal { get; set; }
        public Nullable<int> idIdioma { get; set; }
        public Nullable<int> idDialecto { get; set; }
        public int idPersonal { get; set; }
        public string strComunicacionPorcentaje { get; set; }
        public string strEscrituraProcentaje { get; set; }
        public string strEntendimientoPorcentaje { get; set; }
        public string strLecturaPorcentaje { get; set; }
        public Nullable<System.DateTime> dteFechaRegistro { get; set; }
    }
}
