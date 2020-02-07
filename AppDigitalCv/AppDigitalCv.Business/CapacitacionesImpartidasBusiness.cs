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
    public class CapacitacionesImpartidasBusiness : ICapacitacionesImpartidasBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CapacitacionesImpartidasRepository capacitacionesImpartidasRepository;
        private readonly DocumentosRepository documentosRepository;

        public CapacitacionesImpartidasBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            capacitacionesImpartidasRepository = new CapacitacionesImpartidasRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddCapacitacion(CapacitacionesImpartidadDomainModel capacitacionesImpartidaDomainModel)
        {
            bool respuesta = false;

            TblCapacitacionesImpartidas tblCapacitacionesImpartidas = new TblCapacitacionesImpartidas();
            catDocumentos catDocumentos = new catDocumentos();

            tblCapacitacionesImpartidas.idPersonal = capacitacionesImpartidaDomainModel.idPersonal;
            tblCapacitacionesImpartidas.idTipoCapacitacion = capacitacionesImpartidaDomainModel.idTipoCapacitacion;
            tblCapacitacionesImpartidas.strLugarIntitucion = capacitacionesImpartidaDomainModel.strLugarInstitucion;
            tblCapacitacionesImpartidas.strNombre = capacitacionesImpartidaDomainModel.strNombre;
            tblCapacitacionesImpartidas.strTotalHoras = capacitacionesImpartidaDomainModel.strTotalHoras;

            catDocumentos.TblCapacitacionesImpartidas.Add(tblCapacitacionesImpartidas);

            catDocumentos.strUrl = capacitacionesImpartidaDomainModel.Documentos.StrUrl;

            documentosRepository.Insert(catDocumentos);
            respuesta = true;

            return respuesta;
        }

        public List<CapacitacionesImpartidadDomainModel> GetCapacitacionesImpartidas(int _idPersonal)
        {
            List<CapacitacionesImpartidadDomainModel> capacitacionesImpartidadDomainModels = new List<CapacitacionesImpartidadDomainModel>();

            List<TblCapacitacionesImpartidas> tblCapacitacioneImpartidas = capacitacionesImpartidasRepository.GetAll().Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (TblCapacitacionesImpartidas item in tblCapacitacioneImpartidas)
            {
                CapacitacionesImpartidadDomainModel capacitacionesImpartidadDomainModel = new CapacitacionesImpartidadDomainModel();

                capacitacionesImpartidadDomainModel.id = item.id;
                capacitacionesImpartidadDomainModel.idDocumento = item.idDocumento.Value;
                capacitacionesImpartidadDomainModel.idPersonal = item.idPersonal.Value;
                capacitacionesImpartidadDomainModel.idTipoCapacitacion = item.idTipoCapacitacion.Value;
                capacitacionesImpartidadDomainModel.strLugarInstitucion = item.strLugarIntitucion;
                capacitacionesImpartidadDomainModel.strNombre = item.strNombre;
                capacitacionesImpartidadDomainModel.strTotalHoras = item.strTotalHoras;
                capacitacionesImpartidadDomainModel.TipoCapacitacion = new TipoCapacitacionDomainModel
                {
                    id = item.CatTiposCapacitacion.id,
                    strValor = item.CatTiposCapacitacion.strValor
                };
                capacitacionesImpartidadDomainModel.Documentos = new DocumentosDomainModel
                {
                    IdDocumento = item.catDocumentos.idDocumento,
                    StrUrl = item.catDocumentos.strUrl
                };

                capacitacionesImpartidadDomainModels.Add(capacitacionesImpartidadDomainModel);

            }

            return capacitacionesImpartidadDomainModels;
        }

        public CapacitacionesImpartidadDomainModel GetCapacitacionImpartida(int _id)
        {
            CapacitacionesImpartidadDomainModel capacitacionesImpartidadDomainModel = new CapacitacionesImpartidadDomainModel();

            TblCapacitacionesImpartidas tblCapacitacionesImpartidas = new TblCapacitacionesImpartidas();

            tblCapacitacionesImpartidas = capacitacionesImpartidasRepository.SingleOrDefault(p => p.id == _id);

            capacitacionesImpartidadDomainModel.id = tblCapacitacionesImpartidas.id;
            capacitacionesImpartidadDomainModel.idDocumento = tblCapacitacionesImpartidas.idDocumento.Value;
            capacitacionesImpartidadDomainModel.idPersonal = tblCapacitacionesImpartidas.idPersonal.Value;
            capacitacionesImpartidadDomainModel.idTipoCapacitacion = tblCapacitacionesImpartidas.idTipoCapacitacion.Value;
            capacitacionesImpartidadDomainModel.strLugarInstitucion = tblCapacitacionesImpartidas.strLugarIntitucion;
            capacitacionesImpartidadDomainModel.strNombre = tblCapacitacionesImpartidas.strNombre;
            capacitacionesImpartidadDomainModel.strTotalHoras = tblCapacitacionesImpartidas.strTotalHoras;
            capacitacionesImpartidadDomainModel.TipoCapacitacion = new TipoCapacitacionDomainModel
            {
                id = tblCapacitacionesImpartidas.CatTiposCapacitacion.id,
                strValor = tblCapacitacionesImpartidas.CatTiposCapacitacion.strValor
            };
            capacitacionesImpartidadDomainModel.Documentos = new DocumentosDomainModel
            {
                IdDocumento = tblCapacitacionesImpartidas.catDocumentos.idDocumento,
                StrUrl = tblCapacitacionesImpartidas.catDocumentos.strUrl
            };

            return capacitacionesImpartidadDomainModel;
        }
    }
}
