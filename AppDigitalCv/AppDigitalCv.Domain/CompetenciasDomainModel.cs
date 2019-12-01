using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppDigitalCv.Domain
{
    public class CompetenciasDomainModel
    {
        public int idCompetencia { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public string strTipo { get; set; }
        public bool isChecked { get; set; }
        public HttpPostedFileWrapper file { get; set; }
    }
}
