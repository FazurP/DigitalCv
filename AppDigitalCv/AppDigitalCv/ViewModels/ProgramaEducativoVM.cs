using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ProgramaEducativoVM
    {
        public int idProgramaEducativo { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public int idInstitucionSuperior { get; set; }
        public int idTipoEstudio { get; set; }
    }
}