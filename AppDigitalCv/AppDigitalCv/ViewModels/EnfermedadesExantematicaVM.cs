using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EnfermedadesExantematicaVM
    {
        public int id { get; set; }
        public bool Varicela { get; set; }
        public bool Rubeola { get; set; }
        public bool Sarampion { get; set; }
        public bool Escarlatina { get; set; }
        public bool ExantemaSubito { get; set; }
        public bool EnfermedadManosPiesBoca { get; set; }
    }
}