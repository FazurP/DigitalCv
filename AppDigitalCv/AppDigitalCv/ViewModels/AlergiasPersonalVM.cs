using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class AlergiasPersonalVM
    {
        public int idAlergiasPersonal { get; set; }
        public int idAlergia { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaRegistro { get; set; }
    }
}