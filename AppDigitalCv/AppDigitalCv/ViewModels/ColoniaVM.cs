using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ColoniaVM
    {
        public int IdColonia { get; set; }
        public string StrValor { get; set; }
        public int intCp { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
    }
}