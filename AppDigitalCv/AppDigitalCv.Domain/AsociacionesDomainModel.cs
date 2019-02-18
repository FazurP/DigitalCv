using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class AsociacionesDomainModel
    {
        public int IdAsociacion { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public int IdTipoEmpresa { get; set; }
        //esto cambiara a una lista
        public virtual TipoEmpresaDomainModel TipoEmpresaDomainModel { get; set; }
    }
}
