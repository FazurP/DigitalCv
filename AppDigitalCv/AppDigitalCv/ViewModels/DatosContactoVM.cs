using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DatosContactoVM
    {
        
        public int IdDatosContacto { get; set; }

        public int IdPersonal { get; set; }

        public int IdTelefono { get; set; }

        [RegularExpression("[a-zA-Z0-9._-]{3,25}[@]{1}(hotmail|gmail|outlook|yahoo){1}[.]{1}(com|mx|net){1}")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string MailPersonal { set; get; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string NombreFacebook { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string NombreTwitter { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoCasa { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoCelular { get; set; }

        [RegularExpression("^[0-9]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoRecados { get; set; }

        [StringLength(50)]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage ="Este Campo es Requerido")]
        [DataType(DataType.Text)]
        public string strNombre { get; set; }

        [StringLength(50)]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DataType(DataType.Text)]
        public string strApellidoPaterno { get; set; }

        [StringLength(50)]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DataType(DataType.Text)]
        public string strApellidoMaterno { get; set; }

        [StringLength(250)]
        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ0-9, ]+$")]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DataType(DataType.Text)]
        public string strDireccion { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        public bool bitContactoEmergencia { get; set; }

        //Objetos de las relaciones


    }
}