using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class TipoEmpresaVM
    {
        public int IdTipoEmpresa { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public virtual ICollection<AsociacionesVM> AsociacionesVM { get; set; }
    }
}