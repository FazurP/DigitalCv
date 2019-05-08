using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class AlergiasPersonalVM
    {
        public int IdAlergiasPersonal { get; set; }

        public int IdAlergia { get; set; }

        public int IdPersonal { get; set; }

        public DateTime dteFechaRegistro { get; set; }
    }
}