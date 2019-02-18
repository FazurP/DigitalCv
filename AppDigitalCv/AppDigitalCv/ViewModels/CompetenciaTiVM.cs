using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CompetenciaTiVM
    {

        public int IdCompetenciaTI { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public bool isChecked { get; set; }
    }
}