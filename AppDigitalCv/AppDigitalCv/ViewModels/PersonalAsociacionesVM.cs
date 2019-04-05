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
        public string DteFecha { get; set; }

        [RegularExpression("^[a-záéíóúñA-ZÁÉÍÓÚÑ ]+$")]
        [Required(ErrorMessage = "La Participacion es Obligatoria")]
        public string StrTipoParticipacion { get; set; }

        public virtual PersonalVM PersonalVM { get; set; }
        public virtual AsociacionesVM AsociacionesVM { get; set; }
    }
}