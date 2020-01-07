using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class LenguasVM
    {
        public int id { get; set; }
        [Required]
        public int idLengua { get; set; }
        public int idPersonal { get; set; }
        [Required]
        public string strEscritura { get; set; }
        [Required]
        public string strLectura { get; set; }
        [Required]
        public string strEntendimiento { get; set; }
        [Required]
        public string strComunicacion { get; set; }

        public DialectoVM Dialecto { get; set; }
    }
}