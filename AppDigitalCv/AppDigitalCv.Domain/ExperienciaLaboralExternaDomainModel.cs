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
        public string strInstitucionEmpresa { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaFinal { get; set; }
        public string strActividades { get; set; }
        public string strMotivoConclusion { get; set; }
        public string strPuestoDesempeñado { get; set; }

        //Objetos de las relaciones

        public DocumentosDomainModel Documentos { get; set; }

    }
}
