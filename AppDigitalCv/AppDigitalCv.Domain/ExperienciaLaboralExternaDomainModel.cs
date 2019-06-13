using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ExperienciaLaboralExternaDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public int idTipoPersonal { get; set; }
        public int idPeriodo { get; set; }
        public string strInstitucionEmpresa { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaFinal { get; set; }
        public string strActividades { get; set; }
        public string strMotivoConclusion { get; set; }
        public string strPuestoDesempeñado { get; set; }
        public DocumentosDomainModel documentosDM { get; set; }

        // Estos atributos son para mostrar datos en el modal de edicion

        public string documento { get; set; }
        public string tipoPersonal { get; set; }
        public string periodo { get; set; }
    }
}
