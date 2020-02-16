using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PersonalAsociacionesVM
    {
        public int IdPersonal { get; set; }
        public int IdAsociacion { get; set; }

        [Required(ErrorMessage ="Este Campo es Requerido")]
        public string DteFecha { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string StrTipoParticipacion { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string strFuncionDesempeñada { get; set; }

        public virtual PersonalVM PersonalVM { get; set; }
        public virtual AsociacionesVM Asociaciones{ get; set; }
    }
}