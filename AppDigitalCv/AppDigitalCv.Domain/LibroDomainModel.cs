using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class LibroDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public int idPais { get; set; }
        public string strAutores { get; set; }
        public string strTituloLibro { get; set; }
        public string strTipoParticipacion { get; set; }
        public string strEstadoActual { get; set; }
        public string strEditorial { get; set; }
        public int Paginas { get; set; }
        public string strEdicion { get; set; }
        public string strTiraje { get; set; }
        public string strISBM { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string strProposito { get; set; }

    }
}
