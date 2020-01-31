using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class HistorialAcademicoDomainModel
    {
        public string strNombre { get; set; }
        public int InstitucionAcredita { get; set; }
        public int Status { get; set; }
        public bool bitReconocimientePNPC { get; set; }
        public int FuenteFinanciamiento { get; set; }
        public DoctoradoDomainModel Doctorado { get; set; }
        public MaestriaDomainModel Maestria { get; set; }
        public LicenciaturaIngenieriaDomainModel LicenciaturaIngenieria { get; set; }
        public BachilleratoDomainModel Bachillerato { get; set; }
        public DocumentosDomainModel Documentos { get; set; }
        public int idPersonal { get; set; }
        public DateTime dteFechaInicio { get; set; }

        //Distribuidores

        public int Type { get; set; }
    }
}
