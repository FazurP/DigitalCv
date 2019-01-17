using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    //esta es la interfaz ligada a la clase donde se encuentran los metodos de adminsitracion CRUD
    public interface IDocumentosBusiness
    {
        string AddUpdateDocumento(DocumentosDomainModel documentosDM);
        
        /// <summary>
        /// Este metodo se encarga de guardar un documento y al finalizr la taera devuelve dicho documento
        /// </summary>
        /// <param name="documentosDM">la entidad del documento</param>
        /// <returns>regresa la entidad  documento</returns>
        DocumentosDomainModel AddDocumento(DocumentosDomainModel documentosDM);
    }

    
}
