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
    public class IdiomaBusiness : IIdiomasBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IdiomaRepository idiomaRepository;
        private readonly DocumentosRepository documentosRepository;

        public IdiomaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            idiomaRepository = new IdiomaRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddUpdateIdioma(IdiomasDomainModel idiomasDomainModel) 
        {
            bool respueta = false;

            if (idiomasDomainModel.id > 0)
            {
                TblIdioma tblIdioma = idiomaRepository.GetAll(p => p.id == idiomasDomainModel.id).FirstOrDefault();

                if (tblIdioma != null)
                {
                    tblIdioma.idDocumento = idiomasDomainModel.idDocumento;
                    tblIdioma.idIdioma = idiomasDomainModel.idIdioma;
                    tblIdioma.idNivelConocimiento = idiomasDomainModel.idNivelConocimiento;
                }
            }
            else 
            {
                TblIdioma tblIdioma = new TblIdioma();
                catDocumentos catDocumentos = new catDocumentos();

                catDocumentos.strUrl = idiomasDomainModel.Documentos.StrUrl;
                tblIdioma.idIdioma = idiomasDomainModel.idIdioma;
                tblIdioma.idNivelConocimiento = idiomasDomainModel.idNivelConocimiento;
                tblIdioma.idPersonal = idiomasDomainModel.idPersonal;

                catDocumentos.TblIdioma.Add(tblIdioma);

                documentosRepository.Insert(catDocumentos);
                respueta = true;
            }

            return respueta;
        }

        public List<IdiomasDomainModel> GetAllIdiomasByPersonal(int _idPersonal) 
        {
            List<IdiomasDomainModel> idiomasDomainModels = new List<IdiomasDomainModel>();
            List<TblIdioma> TblIdioma = new List<TblIdioma>();

            TblIdioma = idiomaRepository.GetAll().Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (TblIdioma item in TblIdioma)
            {
                IdiomasDomainModel idiomasDomainModel = new IdiomasDomainModel();

                idiomasDomainModel.id = item.id;
                idiomasDomainModel.idDocumento = item.id;
                idiomasDomainModel.idIdioma = item.idIdioma.Value;
                idiomasDomainModel.idNivelConocimiento = item.idNivelConocimiento.Value;
                idiomasDomainModel.idPersonal = item.idPersonal.Value;
                idiomasDomainModel.Idioma = new IdiomaDomainModel { strDescripcion = item.catIdioma.strDescripcion };
                idiomasDomainModel.NivelConocimiento = new NivelConocimientoDomainModel { strValor = item.CatNivelConocimiento.strValor };
                idiomasDomainModel.Documentos = new DocumentosDomainModel { StrUrl = item.catDocumentos.strUrl};

                idiomasDomainModels.Add(idiomasDomainModel);
            }

            return idiomasDomainModels;
        }
        public IdiomasDomainModel GetIdiomaById(int _id) 
        {
            IdiomasDomainModel idiomasDomainModel = new IdiomasDomainModel();
            TblIdioma tblIdioma = new TblIdioma();

            tblIdioma = idiomaRepository.GetAll().First(p => p.id == _id);

            if (tblIdioma != null)
            {
                idiomasDomainModel.id = tblIdioma.id;
                idiomasDomainModel.idDocumento = tblIdioma.idDocumento.Value;
                idiomasDomainModel.idIdioma = tblIdioma.idIdioma.Value;
                idiomasDomainModel.idNivelConocimiento = tblIdioma.idNivelConocimiento.Value;
                idiomasDomainModel.idPersonal = tblIdioma.idPersonal.Value;
                idiomasDomainModel.NivelConocimiento = new NivelConocimientoDomainModel 
                {
                strValor = tblIdioma.CatNivelConocimiento.strValor
                };
                idiomasDomainModel.Idioma = new IdiomaDomainModel 
                {
                strDescripcion = tblIdioma.catIdioma.strDescripcion
                };
                idiomasDomainModel.Documentos = new DocumentosDomainModel
                {
                    StrUrl = tblIdioma.catDocumentos.strUrl
                };

            }

            return idiomasDomainModel;
        }

        public bool DeleteIdioma(IdiomasDomainModel idiomasDomainModel) 
        {
            bool respuesta = false;

            if (idiomasDomainModel.id > 0)
            {
                documentosRepository.Delete(p => p.idDocumento == idiomasDomainModel.idDocumento);
            }

            return respuesta;
        }
    }
}
