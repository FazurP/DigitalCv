using AppDigitalCv.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PersonalVM
    {
        
        public int idPersonal { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingresa solo caracteres validos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es Requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingresa solo caracteres validos")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es Requerido")]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingresa solo caracteres validos")]
        public string ApellidoMaterno { get; set; }

        //[RegularExpression("^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\\d]{3})?$", ErrorMessage = "Ingresa un RFC valido")]
        [Required(ErrorMessage = "El RFC es requerido")]
        public string RFC { get; set; }

        //[RegularExpression("^[a-zA-Z]{4,4}[0-9]{6}[a-zA-Z]{6,6}[0-9]{2}$")]
        [Required(ErrorMessage = "El CURP es requerido")]
        public string Curp { get; set; }

        [Required(ErrorMessage = "La HomoClave es requerido")]
        public string HomoClave { get; set; }

        //[Required(ErrorMessage = "La Fecha de Nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }

        ///[Required(ErrorMessage ="La evidencia en archivo es obligatoria")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.pdf)$", ErrorMessage = "Ingresa un Archivo con formato PDF, por favor")]
        //[DataType(DataType.Upload)]
        [Required(ErrorMessage = "El archivo es obligatorio")]
        public HttpPostedFileWrapper ArchivoRfc { get; set; }

        [Required(ErrorMessage = "El archivo es obligatorio")]
        //[DataType(DataType.Upload)]
        public HttpPostedFileWrapper ArchivoCurp { get; set; }

        [Required(ErrorMessage = "La Semblanza es requerida")]
        public string strLogros { get; set; }

        [Required(ErrorMessage = "El archivo es obligatorio")]
        public HttpPostedFileWrapper ImageFile { get; set; }    
        public string strUrlFoto { get; set; }
        public string strUrlCurp { get; set; }
        public string strUrlRfc { get; set; }
        public string StrGenero { get; set; }
        public int IdEstadoCivil { get; set; }

        public int idTipoSangre { get; set; }
        public TipoSangreVM TipoSangreVM { get; set; }

    }




}