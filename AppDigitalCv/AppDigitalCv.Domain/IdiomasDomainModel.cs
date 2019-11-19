using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class IdiomasDomainModel
    {
        public int id { get; set; }
        public int idIdioma { get; set; }
        public int idNivelConocimiento { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }

        public DocumentosDomainModel documentosDomain { get; set; }
        public IdiomaDomainModel idiomaDomain { get; set; }
        public NivelConocimientoDomainModel nivelConocimientoDomain { get; set; }
    }
}
