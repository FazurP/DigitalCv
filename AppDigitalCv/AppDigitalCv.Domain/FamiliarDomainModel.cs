using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class FamiliarDomainModel
    {
        public int IdFamiliar { get; set; }
        public string StrNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string StrOcupacion { get; set; }
        public string StrDomicilio { get; set; }
        public string DteFechaNacimiento { get; set; }
        public int IdParentesco { get; set; }
        public int IdPersonal { get; set; }

        //Objetos de las relaciones
      
        public ParentescoDomainModel Parentesco { get; set; }
    }
}
