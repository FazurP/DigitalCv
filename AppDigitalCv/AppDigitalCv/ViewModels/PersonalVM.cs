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
        [Required(ErrorMessage="Debes Ingresar el Nombre")]
        public string strNombre { get; set; }
        [Required(ErrorMessage ="Debes Ingresar el Apelido Paterno")]
        public string strApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Debes Ingresar el Apelido Materno")]
        public string strApellidoMaterno { get; set; }
    }


     

}