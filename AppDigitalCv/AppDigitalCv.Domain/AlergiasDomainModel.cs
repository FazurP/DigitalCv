using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class AlergiasDomainModel
    {
        

        public int IdAlergia { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public int IdtipoAlergia { get; set; }
        //Este atributo se pone para identificar la alergia de la persona
        public int IdPersonal { get; set; } 


    }
}
