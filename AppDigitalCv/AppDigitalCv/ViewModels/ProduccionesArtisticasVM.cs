using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ProduccionesArtisticasVM
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idPersonal { get; set; }
        public int idStatus { get; set; }
        public int idDocumento { get; set; }
        public int idProduccionesArtisticas { get; set; }
        public DocumentosVM documentosVM { get; set; }
        public string strAutor { get; set; }
        public string strNombreObra { get; set; }
        public string strDescripcion { get; set; }
        public string strImpactoInvestigacion { get; set; }
        public string strImpactoMetodologia { get; set; }
        public string strImpactoDiseño { get; set; }
        public string strImpactoInnovacion { get; set; }
        public DateTime dteFechaPublicacion { get; set; }
        public string strLugarPresento { get; set; }
        public string strProposito { get; set; }
        public bool bitLigarCurriculum { get; set; }
        public string strNombreDocumento { get; set; }
    }
}