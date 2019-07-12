using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ManualOperacionVM
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idStatus { get; set; }
        public int idPersonal { get; set; }
        public string strAutor { get; set; }
        public string strNombre { get; set; }
        public string strDescripcion { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public DateTime dteFechaPublicacion { get; set; }
    }
}