using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class LicenciaturaIngenieriaDomainModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcredita { get; set; }
        public int idStatusLicenciatura { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones.

        public InstitucionAcreditaLicenciaturaDomainModel InstitucionAcreditaLicenciatura { get; set; }
        public StatusLicenciaturaDomainModel StatusLicenciatura { get; set; }
        public List<DocumentosProfesionalesDomainModel> DocumentosProfesionales { get; set; }
    }
}
