using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DocumentosProfesionalesDomainModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idDoctorado { get; set; }
        public int idMaestria { get; set; }
        public int idLicenciaturaIng { get; set; }
        public int idBachillerato { get; set; }
        public DoctoradoDomainModel Doctorado { get; set; }
        public MaestriaDomainModel Maestria { get; set; }
        public LicenciaturaIngenieriaDomainModel LicenciaturaIngenieria { get; set; }
        public BachilleratoDomainModel Bachillerato { get; set; }
        public int Type { get; set; }
    }
}
