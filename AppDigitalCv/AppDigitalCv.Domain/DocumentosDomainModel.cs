using AppDigitalCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppDigitalCv.Domain
{
    public class DocumentosDomainModel
    {
        /// <summary>
        /// recordemos que todas las propiedades son en mayusculas
        /// </summary>
        public int IdDocumento { get; set; }
        public string StrDescripcion { get; set; }
        public string StrObservacion { get; set; }
        public string StrUrl { get; set; }
        //listo ya tenemos vinculado  en el domain model ahora hay que modificar el viewmodel con la misma clase
        //public virtual ICollection<PremiosDocenteDomainModel> PremiosDocenteDomainModel { get; set; }
        public HttpPostedFileWrapper DocumentoFile { get; set; }
    }
}
