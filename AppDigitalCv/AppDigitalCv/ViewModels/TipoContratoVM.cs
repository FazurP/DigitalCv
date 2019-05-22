using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class TipoContratoVM
    {
        public int idTipoContrato { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public int idSalario { get; set; }
        public int idCategoria { get; set; }
    }
}