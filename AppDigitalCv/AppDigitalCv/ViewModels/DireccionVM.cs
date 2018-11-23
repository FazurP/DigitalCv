using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DireccionVM
    {
        public int IdDireccion { get; set; }

        //[RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Ingrese Caracteres Validos")]
        public string StrCalle { get; set; }

        //[RegularExpression(@"/^[0-9]$/", ErrorMessage = "Ingrese Caracteres Validos, Solo Numeros")]
        public string StrNumeroInterior { get; set; }

        //[RegularExpression(@"/^[0-9]$/", ErrorMessage = "Ingrese Caracteres Validos, Solo Numeros")]
        public string StrNumeroExterior { get; set; }

        public int IdColonia { get; set; }

        public int IdEstado { get; set; }

        public int IdPais { get; set; }

        public int IdMunicipio { get; set; }

        public ColoniaVM ColoniaVM { get; set; }
    }
}