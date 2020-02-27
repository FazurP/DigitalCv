using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class TipoDocumentoBusiness : ITipoDocumentoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TipoDocumentoRepository tipoDocumentoRepository;
        private readonly DocumentacionPersonalRepository documentacionPersonalRepository;

        public TipoDocumentoBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            tipoDocumentoRepository = new TipoDocumentoRepository(unitOfWork);
            documentacionPersonalRepository = new DocumentacionPersonalRepository(unitOfWork);
        }

        public List<TipoDocumentoDomainModel> GetAllTiposDocumentoPendientes(int _idPersonal) 
        {
            List<TipoDocumentoDomainModel> tipoDocumentoDomainModels = new List<TipoDocumentoDomainModel>();
            List<CatTipoDocumento> tipoDocumento = new List<CatTipoDocumento>();

            tipoDocumento = tipoDocumentoRepository.GetAll().ToList();

            foreach (CatTipoDocumento item in tipoDocumento)
            {
                //if (!documentacionPersonalRepository.Exists(p => p.idPersonal == _idPersonal && p.idTipoDocumento == item.id))
                //{
                    TipoDocumentoDomainModel tipoDocumentoDomainModel = new TipoDocumentoDomainModel();

                    tipoDocumentoDomainModel.id = item.id;
                    tipoDocumentoDomainModel.strValor = item.strValor;

                    tipoDocumentoDomainModels.Add(tipoDocumentoDomainModel);
                //}
              
            }

            TipoDocumentoDomainModel tipoDocumentoDomainModel1 = new TipoDocumentoDomainModel();

            tipoDocumentoDomainModel1.id = 0;
            tipoDocumentoDomainModel1.strValor = "Seleccionar";

            tipoDocumentoDomainModels.Insert(0, tipoDocumentoDomainModel1);

            return tipoDocumentoDomainModels;
        }
    }
}
