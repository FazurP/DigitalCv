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
    public class CapacitacionesRecibidadBusiness : ICapacitacionesRecibidasBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CapacitacionesRecibidasRepository capacitacionesRecibidadRepository;
        private readonly DocumentosRepository documentosRepository;

        public CapacitacionesRecibidadBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            capacitacionesRecibidadRepository = new CapacitacionesRecibidasRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddCapacitacion(CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel)
        {

            bool respuesta = false;

            TblCapacitacionesRecibidas tblCapacitacionesRecibidas = new TblCapacitacionesRecibidas();

            tblCapacitacionesRecibidas.idTipoCapacitacion = capacitacionesRecibidasDomainModel.idTipoCapacitacion;
            tblCapacitacionesRecibidas.idPersonal = capacitacionesRecibidasDomainModel.idPersonal;
            tblCapacitacionesRecibidas.strInstitucionAcredita = capacitacionesRecibidasDomainModel.strInstitucionAcredita;
            tblCapacitacionesRecibidas.strNombre = capacitacionesRecibidasDomainModel.strNombre;
            tblCapacitacionesRecibidas.strTotalHoras = capacitacionesRecibidasDomainModel.strTotalHoras;

            catDocumentos catDocumentos = new catDocumentos();

            catDocumentos.TblCapacitacionesRecibidas.Add(tblCapacitacionesRecibidas);

            catDocumentos.strUrl = capacitacionesRecibidasDomainModel.Documentos.StrUrl;

            documentosRepository.Insert(catDocumentos);
            respuesta = true;


            return respuesta;
        }

        public List<CapacitacionesRecibidasDomainModel> GetCapacitacionesRecibidas(int _idPersonal)
        {
            List<CapacitacionesRecibidasDomainModel> capacitacionesRecibidasDomainModels = new List<CapacitacionesRecibidasDomainModel>();
            List<TblCapacitacionesRecibidas> tblCapacitacionesRecibidas = new List<TblCapacitacionesRecibidas>();

            tblCapacitacionesRecibidas = capacitacionesRecibidadRepository.GetAll().Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (TblCapacitacionesRecibidas item in tblCapacitacionesRecibidas)
            {
                CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel = new CapacitacionesRecibidasDomainModel();

                capacitacionesRecibidasDomainModel.id = item.id;
                capacitacionesRecibidasDomainModel.idDocumento = item.idDocumento.Value;
                capacitacionesRecibidasDomainModel.idPersonal = item.idPersonal.Value;
                capacitacionesRecibidasDomainModel.idTipoCapacitacion = item.idTipoCapacitacion.Value;
                capacitacionesRecibidasDomainModel.strInstitucionAcredita = item.strInstitucionAcredita;
                capacitacionesRecibidasDomainModel.strNombre = item.strNombre;
                capacitacionesRecibidasDomainModel.strTotalHoras = item.strTotalHoras;
                capacitacionesRecibidasDomainModel.TipoCapacitacion = new TipoCapacitacionDomainModel
                {
                    id = item.CatTiposCapacitacion.id,
                    strValor = item.CatTiposCapacitacion.strValor
                };
                capacitacionesRecibidasDomainModel.Documentos = new DocumentosDomainModel
                {
                    IdDocumento = item.catDocumentos.idDocumento,
                    StrUrl = item.catDocumentos.strUrl
                };

                capacitacionesRecibidasDomainModels.Add(capacitacionesRecibidasDomainModel);
            }

            return capacitacionesRecibidasDomainModels;
        }

        public CapacitacionesRecibidasDomainModel GetCapacitacionRecibida(int _id)
        {
            CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel = new CapacitacionesRecibidasDomainModel();
            TblCapacitacionesRecibidas tblCapacitacionesRecibidas = new TblCapacitacionesRecibidas();

            tblCapacitacionesRecibidas = capacitacionesRecibidadRepository.SingleOrDefault(p => p.id == _id);

            capacitacionesRecibidasDomainModel.id = tblCapacitacionesRecibidas.id;
            capacitacionesRecibidasDomainModel.idDocumento = tblCapacitacionesRecibidas.idDocumento.Value;
            capacitacionesRecibidasDomainModel.idPersonal = tblCapacitacionesRecibidas.idPersonal.Value;
            capacitacionesRecibidasDomainModel.idTipoCapacitacion = tblCapacitacionesRecibidas.idTipoCapacitacion.Value;
            capacitacionesRecibidasDomainModel.strInstitucionAcredita = tblCapacitacionesRecibidas.strInstitucionAcredita;
            capacitacionesRecibidasDomainModel.strNombre = tblCapacitacionesRecibidas.strNombre;
            capacitacionesRecibidasDomainModel.strTotalHoras = tblCapacitacionesRecibidas.strTotalHoras;
            capacitacionesRecibidasDomainModel.TipoCapacitacion = new TipoCapacitacionDomainModel
            {
                id = tblCapacitacionesRecibidas.CatTiposCapacitacion.id,
                strValor = tblCapacitacionesRecibidas.CatTiposCapacitacion.strValor
            };
            capacitacionesRecibidasDomainModel.Documentos = new DocumentosDomainModel
            {
                IdDocumento = tblCapacitacionesRecibidas.catDocumentos.idDocumento,
                StrUrl = tblCapacitacionesRecibidas.catDocumentos.strUrl
            };

            return capacitacionesRecibidasDomainModel;
        }

        public bool DeleteCapacitacion(CapacitacionesRecibidasDomainModel capacitacionesRecibidasDomainModel)
        {
            bool respuesta = false;

            if (capacitacionesRecibidasDomainModel.id > 0)
            {
                capacitacionesRecibidadRepository.Delete(p => p.id == capacitacionesRecibidasDomainModel.id);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
