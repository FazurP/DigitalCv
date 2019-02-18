using AppDigitalCv.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class DireccionVM
    {
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "La calle es requerida")]
        public string StrCalle { get; set; }

        [Required(ErrorMessage = "El numero interior es requerido")]
        public string StrNumeroInterior { get; set; }

        [Required(ErrorMessage = "El numero exterior es requerido")]
        public string StrNumeroExterior { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar una colonia")]
        public int IdColonia { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar un estado")]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar un pais")]
        public int IdPais { get; set; }

        [Required(ErrorMessage = "Es necesario seleccionar un municipio")]
        public int IdMunicipio { get; set; }

        public ColoniaVM ColoniaVM { get; set; }
        ///este es un cambio temporal
    }
}