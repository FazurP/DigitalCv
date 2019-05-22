using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DatosLaboralesDocenteDomainModel
    {
        public int idDatosLaboralesDocente { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public int idProgramaEducativo { get; set; }
        public int idTipoContrato { get; set; }
        public int idPersonal { get; set; }
        public int idCuerpoAcademico { get; set; }
        public int idEdificio { get; set; }
        public int idUnidadesAcademicas { get; set; }
        public string strObjetivoPersonal { get; set; }
        public string strNumeroExtencion { get; set; }
        public decimal dcmSalariosHoras { get; set; }
    }
}
