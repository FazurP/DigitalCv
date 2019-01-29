
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class EstadoSaludDomainModel
    {
        public int idEnfermedadPersonal { get; set; }
        public int idEnfermedad { get; set; }
        public int idPersonal { get; set; }
        public string NombreEnfermedad { get; set; }
        //cambiamos esta propiedad
        public string dteFechaRegistro { get; set; }
        public virtual PersonalDomainModel PersonalDomainModel { get; set; }
        public virtual EnfermedadDomainModel EnfermedadDomainModel { get; set; }

    }
}
