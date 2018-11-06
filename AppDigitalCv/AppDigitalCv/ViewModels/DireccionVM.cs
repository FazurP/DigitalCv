using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DireccionVM
    {
        //catDireccion
        public int idDireccion { get; set; }
        public string strCalle { get; set; }
        public string strNumeroInterior { get; set; }
        public string strNumeroExterior { get; set; }
        public int idColonia { get; set; }

        public int IdEstado { get; set; }
        public int IdPais { get; set; }
    }
}