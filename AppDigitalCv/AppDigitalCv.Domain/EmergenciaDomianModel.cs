using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class EmergenciaDomianModel
    {
        public int IdEmergencia { get; set; }
        public string StrNombre { get; set; }
        public string StrTelefono { get; set; }
        public string StrDireccion { get; set; }
        public int IdParentesco { get; set; }
        public int IdPersonal { get; set; }

        //public virtual ParentescoDomainModel ParentescoDomainModel { get; set; }
        //public virtual PersonalDomainModel PersonalDomainModel { get; set; }

    }
}
