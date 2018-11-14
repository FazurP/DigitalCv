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
        public HttpPostedFileWrapper ArchivoRfc { get; set; }

        [Required(ErrorMessage = "El archivo es obligatorio")]
        //[DataType(DataType.Upload)]
        public HttpPostedFileWrapper ArchivoCurp { get; set; }

    }
}