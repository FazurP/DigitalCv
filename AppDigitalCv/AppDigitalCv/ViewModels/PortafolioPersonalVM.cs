using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PortafolioPersonalVM
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public string strPeriodo { get; set; }
        public string strAño { get; set; }
        public string strTipo { get; set; }
        public string strUrl { get; set; }
    }
}