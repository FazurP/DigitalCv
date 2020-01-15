using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class BachilleratoDomainModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaBachillerato { get; set; }
        public int idDocumento { get; set; }

        //Objetos de las relaciones.

        public DocumentosDomainModel Documentos { get; set; }
        public InstitucionAcreditaBachilleratoDomainModel InstitucionAcreditaBachillerato { get; set; }
    }
}
