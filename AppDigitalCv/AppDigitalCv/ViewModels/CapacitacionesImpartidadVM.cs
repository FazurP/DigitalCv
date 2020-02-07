using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CapacitacionesImpartidadVM
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idTipoCapacitacion { get; set; }
        public int idPersonal { get; set; }
        public string strNombre { get; set; }
        public string strLugarInstitucion { get; set; }
        public string strTotalHoras { get; set; }

        //Objetos de las Relaciones

        public TipoCapacitacionVM TipoCapacitacion { get; set; }
        public DocumentosVM Documentos { get; set; }
    }
}