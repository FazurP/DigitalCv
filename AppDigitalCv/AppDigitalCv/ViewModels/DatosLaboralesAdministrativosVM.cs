using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DatosLaboralesAdministrativosVM
    {
        public int idDatosLaboralesAdministrativos { get; set; }
        public int idArea { get; set; }
        public int idTipoContrato { get; set; }
        public int idPersonal { get; set; }
        public int idUnidadesAcademicas { get; set; }
        public DateTime dteFechaNombremientoConsejo { get; set; }
        public DateTime dteFechaInicioUttt { get; set; }
        public DateTime dteFechaRegistro { get; set; }
    }
}