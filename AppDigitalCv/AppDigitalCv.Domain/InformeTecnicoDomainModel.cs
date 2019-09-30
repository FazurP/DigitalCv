using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class InformeTecnicoDomainModel
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public int idStatus { get; set; }
        public string strAutor { get; set; }
        public string strNombreProyecto { get; set; }
        public string strAlcance { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public string enumEstadoActual { get; set; }
        public DateTime dteElaboracionInforme { get; set; }
        public int numeroPaginas { get; set; }
        public int idPais { get; set; }
        public string enumProposito { get; set; }
        public DocumentosDomainModel DocumentosDM { get; set; }
        public bool bitLigarCurriculum { get; set; }
        public string strNombreDocumento { get; set; }

    }
}
