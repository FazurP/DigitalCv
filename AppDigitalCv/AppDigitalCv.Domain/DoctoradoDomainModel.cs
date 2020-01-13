using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DoctoradoDomainModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaDoctorado { get; set; }
        public int idStatusDoctorado { get; set; }
        public int idDocumento { get; set; }
        public int idFuentaFinaciamientoDoctorado { get; set; }
        public bool bitReconocimientePNPC { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public InstitucionAcreditaDoctoradoDomainModel InstitucionAcreditaDoctorado { get; set; }
        public StatusDoctoradoDomainModel StatusDoctorado { get; set; }
        public DocumentosDomainModel Documentos { get; set; }
        public FuenteFinanciamientoDoctoradoDomainModel FuenteFinanciamientoDoctorado { get; set; }
    }
}
