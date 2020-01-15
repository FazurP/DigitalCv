using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class MaestriaVM
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaMaestria { get; set; }
        public int idStatusMaestria { get; set; }
        public int idDocumento { get; set; }
        public int idFuenteFinanciamientoMaestria { get; set; }
        public bool bitReconocidoPNPC { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public InstitucionAcreditaMaestriaVM InstitucionAcreditaMaestria { get; set; }
        public StatusMaestriaVM StatusMaestria { get; set; }
        public DocumentosVM Documentos { get; set; }
        public FuenteFinaciamientoMaestriaVM FuenteFinaciamientoMaestria { get; set; }
    }
}