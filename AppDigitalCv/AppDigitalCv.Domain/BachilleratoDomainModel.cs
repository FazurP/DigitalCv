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
        //Objetos de las relaciones.
        public InstitucionAcreditaBachilleratoDomainModel InstitucionAcreditaBachillerato { get; set; }
        public List<DocumentosProfesionalesDomainModel> DocumentosProfesionales { get; set; }
    }
}
