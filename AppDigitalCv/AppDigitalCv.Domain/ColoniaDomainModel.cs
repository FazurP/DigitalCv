using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ColoniaDomainModel
    {
        public int IdColonia { get; set; }
        public string StrValor { get; set; }
        public int IntCp { get; set; }
        public Nullable<int> IdMunicipio { get; set; }

        //Objetos de las relaciones

        public MunicipioDomainModel Municipio { get; set; }
    }
}
