using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ColoniaDomainModel
    {

        public int id { get; set; }
        public string strValor { get; set; }
        public int intCp { get; set; }
        public Nullable<int> idMunicipio { get; set; }

    }
}
