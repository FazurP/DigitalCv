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
        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un familiar d ela base de datos
        /// </summary>
        /// <param name="IdDocumento">recive un identificador del tipo IdDocumento</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        bool DeleteDocumento(int IdDocumento);
        /// <summary>
        /// Este metodo se encarga de consultar un documento por ID
        /// </summary>
        /// <param name="IdDocumento">el identificador del documento</param>
        /// <returns>retorna una entidad del documento</returns>
        DocumentosDomainModel GetDocumentoByIdDocumento(int IdDocumento);
    }

    
}
