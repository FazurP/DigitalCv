using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class MunicipioDomainModel
    {
        public int IdMunicipio { get; set; }
        public string StrValor { get; set; }
        public Nullable<int> IdEstado { get; set; }

        //Objetos de las relaciones

        public EstadoDomainModel Estado { get; set; }
    }
}
