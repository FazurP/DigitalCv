using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class IdiomaDialectoVM
    {
        public int IdIdiomaDialectoPersonal { get; set; }
        public Nullable<int> IdIdioma { get; set; }
      
        public Nullable<int> IdDialecto { get; set; }
        public int IdPersonal { get; set; }
      
        public string StrComunicacionPorcentaje { get; set; }
     
        public string StrEscrituraProcentaje { get; set; }
    
        public string StrEntendimientoPorcentaje { get; set; }
     
        public string StrLecturaPorcentaje { get; set; }
        public Nullable<System.DateTime> DteFechaRegistro { get; set; }
    }
}