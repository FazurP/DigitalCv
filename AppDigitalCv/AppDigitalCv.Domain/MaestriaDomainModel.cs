using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class MaestriaDomainModel
    {
        public int id { get; set; }
        public string strNombre { get; set; }
        public int idInstitucionAcreditaMaestria { get; set; }
        public int idStatusMaestria { get; set; }
        public int idFuenteFinanciamientoMaestria { get; set; }
        public bool bitReconocidoPNPC { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public InstitucionAcreditaMaestriaDomainModel InstitucionAcreditaMaestria { get; set; }
        public StatusMaestriaDomainModel StatusMaestria { get; set; }
        public FuenteFinaciamientoMaestriaDomainModel FuenteFinaciamientoMaestria { get; set; }
        public List<DocumentosProfesionalesDomainModel> DocumentosProfesionales { get; set; }
    }
}
