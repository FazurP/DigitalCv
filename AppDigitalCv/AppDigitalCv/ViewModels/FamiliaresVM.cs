using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class FamiliaresVM
    {
        public ParentescoVM PadreVM { get; set; }
        public ParentescoVM MadreVM { get; set; }
        public ParentescoVM ParejaVM { get; set; }

    }
}