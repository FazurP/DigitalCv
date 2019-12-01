using AppDigitalCv.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.ViewModels
{
    public class DocumentacionPersonalV2VM
    {

        public int idPesonal { get; set; }
        public int idDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }

        
    }
}