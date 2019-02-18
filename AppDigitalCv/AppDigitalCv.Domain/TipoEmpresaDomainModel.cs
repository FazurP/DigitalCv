using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class TipoEmpresaDomainModel
    {
        public int IdTipoEmpresa { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public virtual ICollection<AsociacionesDomainModel> AsociacionesDomainModels { get; set; }
    }
}
