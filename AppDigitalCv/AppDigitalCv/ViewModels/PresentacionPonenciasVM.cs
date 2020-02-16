using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PresentacionPonenciasVM
    {
        public int id { get; set; }
        public int idPersonal { get; set; }

        [Required]
        public string strNombre { get; set; }
        [Required]
        public string strLugarInstitucionPresento { get; set; }
        [Required]
        public string strAño { get; set; }
    }
}