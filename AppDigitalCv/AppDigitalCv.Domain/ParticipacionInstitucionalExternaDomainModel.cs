using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ParticipacionInstitucionalExternaDomainModel
    {
        public int id { get; set; }
        public int idCatInstitucionSuperior { get;set; }
        public int idCatPeriodo { get; set; }
        public int idCatDocumento { get; set; }
        public int idPersonal { get; set; }
        public string strActividad { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public DocumentosDomainModel documentosDM { get; set; }

        //Estos atributos seran solo para mostrar los datos en el model de actualizar

        public string institucionSuperior { get; set; }
        public string periodo { get; set; }
        public string documento { get; set; }
        public DocumentosDomainModel documentosUpdateDM { get; set; }

    }
}
