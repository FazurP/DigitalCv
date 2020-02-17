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
        public int id { get; set; }
        public int idPesonal { get; set; }
        public int idDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public string dteExpedicion { get; set; }
        public string dteVigenciaDocumento { get; set; }
        public virtual DocumentosVM Documentos { get; set; }

        
    }
}