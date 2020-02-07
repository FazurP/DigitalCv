using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CapacitacionesRecibidasDomainModel 
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public int idTipoCapacitacion { get; set; }
        public string strNombre { get; set; }
        public string strTotalHoras { get; set; }
        public string strInstitucionAcredita { get; set; }

        //Objetos de las relaciones

        public TipoCapacitacionDomainModel TipoCapacitacion { get; set; }
        public DocumentosDomainModel Documentos { get; set; }
    }
}
