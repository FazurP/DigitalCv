using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EstadoSaludVM
    {
        public int idEnfermedadPersonal { get; set; }
        public int IdPersonal { get; set; }
        public int IdEnfermedad { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
        public PersonalVM PersonalVM { get; set; }
        public EnfermedadVM EnfermedadVM { get; set; }
        public string NombreEnfermedad { get; set; }
    }
}