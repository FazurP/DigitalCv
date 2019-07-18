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
    public class PrototipoBusiness : IPrototipoBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly PrototipoRepository prototipoRepository;

        public PrototipoBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            prototipoRepository = new PrototipoRepository(unitofWork);
        }

        public bool AddUpdatePrototipo(PrototipoDomainModel prototipoDomainModel)
        {

            bool respuesta = false;

            if (prototipoDomainModel.id > 0)
            {

            }
            else
            {
                tblPrototipo tblPrototipo = new tblPrototipo();

                tblPrototipo.idDocumento = prototipoDomainModel.idDocumento;
                tblPrototipo.idPais = prototipoDomainModel.idPais;
                tblPrototipo.idPersonal = prototipoDomainModel.idPersonal;
                tblPrototipo.idStatus = prototipoDomainModel.idStatsu;
                tblPrototipo.strAutor = prototipoDomainModel.strAutor;
                tblPrototipo.strCaracteristicas = prototipoDomainModel.strCaracteristicas;
                tblPrototipo.strEstadoActual = prototipoDomainModel.strEstadoActual;
                tblPrototipo.strInstitucionDestinada = prototipoDomainModel.strInstitucionDestinada;
                tblPrototipo.strNombrePrototipo = prototipoDomainModel.strNombrePrototipo;
                tblPrototipo.strObjetivos = prototipoDomainModel.strObjetivos;
                tblPrototipo.strProposito = prototipoDomainModel.strProposito;
                tblPrototipo.strTipoPrototipo = prototipoDomainModel.strTipoPrototipo;
                tblPrototipo.dteFechaPublicacion = prototipoDomainModel.dteFechaPublicacion;
                tblPrototipo.bitConsideraCurriculum = prototipoDomainModel.bitConsideraCurriculum;

                prototipoRepository.Insert(tblPrototipo);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
