using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class DocumentosBusiness: IDocumentosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentosRepository documentosRepository;
        //listo
        public DocumentosBusiness(IUnitOfWork _unitOfWork)
        {
            ///listo falta agregarlos a el mapper y la unidad d einyeccion de dependicias pero antes de eso
            ///terminemos la clase
            unitOfWork = _unitOfWork;
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un documento
        /// </summary>
        /// <param name="documentosDM">recibe una entidad como documento</param>
        /// <returns>una cadena de confirmación</returns>
        public string AddUpdateDocumento(DocumentosDomainModel documentosDM)
        {
            string resultado = string.Empty;
            if (documentosDM.IdDocumento > 0)  
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                catDocumentos catDocumentos = documentosRepository.SingleOrDefault(p=> p.idDocumento ==  documentosDM.IdDocumento);
                if (catDocumentos != null)
                {
                    catDocumentos.idDocumento = documentosDM.IdDocumento;
                    catDocumentos.strDescripcion = documentosDM.StrDescripcion;
                    catDocumentos.strObservacion = documentosDM.StrObservacion;
                    catDocumentos.strUrl = documentosDM.StrUrl;
                    documentosRepository.Update(catDocumentos);
                    resultado = "Se Actualizo correctamente";
                }
            }
            else
            {
                catDocumentos catDocumentos = new catDocumentos();
                catDocumentos.idDocumento = documentosDM.IdDocumento;
                catDocumentos.strDescripcion = documentosDM.StrDescripcion;
                catDocumentos.strObservacion = documentosDM.StrObservacion;
                catDocumentos.strUrl = documentosDM.StrUrl;
                var record = documentosRepository.Insert(catDocumentos);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }


        /// <summary>
        /// Este metodo se encarga de guardar un documento y al finalizr la taera devuelve dicho documento
        /// </summary>
        /// <param name="documentosDM">la entidad del documento</param>
        /// <returns>regresa la entidad  documento</returns>
        public DocumentosDomainModel AddDocumento(DocumentosDomainModel documentosDM)
        {
            
            string resultado = string.Empty;
            catDocumentos catDocumentos = new catDocumentos();
            catDocumentos.idDocumento = documentosDM.IdDocumento;
            catDocumentos.strDescripcion = documentosDM.StrDescripcion;
            catDocumentos.strObservacion = documentosDM.StrObservacion;
            catDocumentos.strUrl = documentosDM.StrUrl;
            var record = documentosRepository.Insert(catDocumentos);
            Expression<Func<catDocumentos, bool>> predicado = p => p.strUrl.Equals(catDocumentos.strUrl);
            catDocumentos documento= documentosRepository.SingleOrDefault(predicado);
            DocumentosDomainModel documentoDM = new DocumentosDomainModel();
            documentoDM.IdDocumento = documento.idDocumento;
            documentoDM.StrUrl = documento.strUrl;
            return documentoDM;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un familiar d ela base de datos
        /// </summary>
        /// <param name="IdDocumento">recive un identificador del tipo IdDocumento</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteDocumento(int IdDocumento)
        {
            bool respuesta = false;
            Expression<Func<catDocumentos, bool>> predicado = p => p.idDocumento.Equals(IdDocumento);
            documentosRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un documento por ID
        /// </summary>
        /// <param name="IdDocumento">el identificador del documento</param>
        /// <returns>retorna una entidad del documento</returns>
        public DocumentosDomainModel GetDocumentoByIdDocumento(int IdDocumento)
        {
            Expression<Func<catDocumentos, bool>> predicado = p => p.idDocumento.Equals(IdDocumento);
            catDocumentos documento =documentosRepository.SingleOrDefault(predicado);
            DocumentosDomainModel documentosDM = new DocumentosDomainModel();
            documentosDM.IdDocumento = documento.idDocumento;
            documentosDM.StrUrl = documento.strUrl;
            return documentosDM;
        }





    }
}
