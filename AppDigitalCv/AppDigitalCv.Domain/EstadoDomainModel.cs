using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class EstadoDomainModel
    {
        public int IdEstado { get; set; }
        public string StrValor { get; set; }
        public Nullable<int> IdPais { get; set; }

        //Objetos de las relaciones

        public PaisDomainModel Pais { get; set; }
    }
}
