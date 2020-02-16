using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ProductividadInnovadoraDomainModel
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idDocumento { get; set; }
        public DocumentosDomainModel documento { get; set; }
        public int idPersonal { get; set; }
        public string strAutor { get; set; }
        public string strTipoProductividadInnovadora { get; set; }
        public string strTitulo { get; set; }
        public string strDescripcion { get; set; }
        public string strClasificacionInternacionalPatentes { get; set; }
        public string strNumeroRegistro { get; set; }
        public string dteFechaRegistro { get; set; }
        public string strProposito { get; set; }

    }
}
