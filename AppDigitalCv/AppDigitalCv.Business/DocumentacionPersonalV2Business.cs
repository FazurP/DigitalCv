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
    public class DocumentacionPersonalV2Business: IDocumentacionPersonalV2Business
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DocumentacionPersonalV2Repository documentacionPersonalRepository;
        public DocumentacionPersonalV2Business(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            documentacionPersonalRepository = new DocumentacionPersonalV2Repository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un objeto de documentacionPersonal, en la base de datos.
        /// </summary>
        /// <param name="documentacionPersonalDM"></param>
        /// <returns>true o false</returns>
        public bool AddDocumentacionPersonal(DocumentacionPersonalV2DomainModel documentacionPersonalDM)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            tblPremiosDocente tblPremios = new tblPremiosDocente();
            tblDocumentacionPersonal tblDocumentacionPersonal = new tblDocumentacionPersonal();
            tblDocumentacionPersonal.idDocumento = documentacionPersonalDM.idDocumento;
            tblDocumentacionPersonal.idPersonal = documentacionPersonalDM.idPesonal;
            tblDocumentacionPersonal.strIdentificador = documentacionPersonalDM.strIdentificador;
            tblDocumentacionPersonal.strNumeroDocumento = documentacionPersonalDM.strNumeroDocumento;
            tblDocumentacionPersonal.dteVigenciaDocumento = documentacionPersonalDM.dteVigenciaDocumento;

            documentacionPersonalRepository.Insert(tblDocumentacionPersonal);
            respuesta = true;
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un objeto de DocumentacionPersonal, de la base de datos. 
        /// </summary>
        /// <param name="_idDocumento"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>true o false</returns>
        public bool DeleteDocumentacionPersonal(int _idDocumento, int _idPersonal)
        {
            bool respuesta = false;
            Expression<Func<tblDocumentacionPersonal, bool>> predicate = p => p.idDocumento == _idDocumento && p.idPersonal
             == _idPersonal;

            documentacionPersonalRepository.Delete(predicate);
            respuesta = true;
            return respuesta;
        }
    }
}
