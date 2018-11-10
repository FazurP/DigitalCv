using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DocumentoPersonalVM
    {
        public int IdPersonal { get; set; }
        public string UrlCurp { get; set; }
        public string UrlRfc { get; set; }
        public string imgUrlCurp { get; set; }
        public string imgRfc { get; set; }
    }
}