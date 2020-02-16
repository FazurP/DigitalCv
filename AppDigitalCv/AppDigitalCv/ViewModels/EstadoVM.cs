using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EstadoVM
    {
        public int IdEstado { get; set; }
        public string StrValor { get; set; }
        public Nullable<int> IdPais { get; set; }

        //Objetos de las Relaciones

        public PaisVM Pais { get; set; }
    }
}