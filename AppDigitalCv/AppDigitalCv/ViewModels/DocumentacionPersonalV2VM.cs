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
        ListDocumentos documentos = new ListDocumentos();

        public int idPesonal { get; set; }
        public int idDocumento { get; set; }
        public string strNumeroDocumento { get; set; }
        public DateTime dteExpedicion { get; set; }
        public DateTime dteVigenciaDocumento { get; set; }
        public string strIdentificador { get; set; }
        public virtual DocumentosVM DocumentosVM { get; set; }

        
    }
}