using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class HobbieDomainModel
    {
        public int id { get; set; }
        public int idHobbie { get; set; }
        public int idFrecuencia { get; set; }
        public int idPersonal { get; set; }
        public string strTiempoPractica { get; set; }

        public HobbiesDomainModel Hobbies { get; set; }
        public FrecuenciaDomainModel Frecuencia { get; set; }

    }
}
