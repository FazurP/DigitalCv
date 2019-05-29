using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CursosVM
    {
        public int Id { get; set; }
        public CursoVM CursoVM { get; set; }
        public InstitucionSuperiorVM InstitucionSuperiorVM { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public int IdPersonal { get; set; }
        public  string StrUrlDocumento { get; set; }
    }
}