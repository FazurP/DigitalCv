using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DoctoradoVM
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaDoctorado { get; set; }
        public int idStatusDoctorado { get; set; }
        public int idFuentaFinaciamientoDoctorado { get; set; }
        public bool bitReconocimientePNPC { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public InstitucionAcreditaDoctoradoVM InstitucionAcreditaDoctorado { get; set; }
        public StatusDoctoradoVM StatusDoctorado { get; set; }
        public FuenteFinanciamientoDoctoradoVM FuenteFinanciamientoDoctorado { get; set; }
    }
}