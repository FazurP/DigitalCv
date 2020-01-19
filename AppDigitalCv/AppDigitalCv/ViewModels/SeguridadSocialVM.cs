using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class SeguridadSocialVM
    {
        public int id { get; set; }
        public int idInstitucion { get; set; }
        public string strNumero { get; set; }

        //Objetos de las relaciones

        public InstitucionesSaludVM InstitucionesSalud { get; set; }
    }
}