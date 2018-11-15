using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "El archivo es obligatorio")]
        [DataType(DataType.Upload)]
        
        public HttpPostedFileWrapper ArchivoRfc { get; set; }
        ///(^(([a - zA - Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$)
        
        [Required(ErrorMessage = "El archivo es obligatorio")]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf)$", ErrorMessage = "Ingresa un Archivo con formato PDF, por favor")]
        public HttpPostedFileWrapper ArchivoCurp { get; set; }

    }
}