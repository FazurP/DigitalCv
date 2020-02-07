using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CapacitacionesRecibidasVM
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public int idTipoCapacitacion { get; set; }
        public string strNombre { get; set; }
        public string strTotalHoras { get; set; }
        public string strInstitucionAcredita { get; set; }

        //Objetos de las Relaciones

        public TipoCapacitacionVM TipoCapacitacion { get; set; }
        public DocumentosVM Documentos { get; set; }
    }
}