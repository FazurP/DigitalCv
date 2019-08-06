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
                Expression<Func<tblPrototipo, bool>> predicate = p => p.id == prototipoDomainModel.id;
                tblPrototipo tblPrototipo = prototipoRepository.GetAll(predicate).FirstOrDefault();

                if (tblPrototipo != null)
                {
                    tblPrototipo.strAutor = prototipoDomainModel.strAutor;
                    tblPrototipo.strCaracteristicas = prototipoDomainModel.strCaracteristicas;
                    tblPrototipo.strInstitucionDestinada = prototipoDomainModel.strInstitucionDestinada;
                    tblPrototipo.strNombrePrototipo = prototipoDomainModel.strNombrePrototipo;
                    tblPrototipo.strObjetivos = prototipoDomainModel.strObjetivos;
                    prototipoRepository.Update(tblPrototipo);
                    respuesta = true;
                }
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

        public List<PrototipoDomainModel> GetPrototipos(int _idPersonal)
        {
            List<PrototipoDomainModel> prototipos = new List<PrototipoDomainModel>();

            Expression<Func<tblPrototipo, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblPrototipo> tblPrototipos = prototipoRepository.GetAll(predicate).ToList();

            foreach (tblPrototipo tblPrototipo in tblPrototipos)
            {
                PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

                prototipoDM.id = tblPrototipo.id;
                prototipoDM.idDocumento = tblPrototipo.idDocumento.Value;
                prototipoDM.idPais = tblPrototipo.idPais.Value;
                prototipoDM.idPersonal = tblPrototipo.idPersonal.Value;
                prototipoDM.idStatsu = tblPrototipo.idStatus.Value;
                prototipoDM.strAutor = tblPrototipo.strAutor;
                prototipoDM.strCaracteristicas = tblPrototipo.strCaracteristicas;
                prototipoDM.strEstadoActual = tblPrototipo.strEstadoActual;
                prototipoDM.strInstitucionDestinada = tblPrototipo.strInstitucionDestinada;
                prototipoDM.strNombrePrototipo = tblPrototipo.strNombrePrototipo;
                prototipoDM.strObjetivos = tblPrototipo.strObjetivos;
                prototipoDM.strProposito = tblPrototipo.strProposito;
                prototipoDM.strTipoPrototipo = tblPrototipo.strTipoPrototipo;
                prototipoDM.dteFechaPublicacion = tblPrototipo.dteFechaPublicacion.Value;
                prototipoDM.bitConsideraCurriculum = tblPrototipo.bitConsideraCurriculum.Value;
                prototipoDM.strNombreDocumento = tblPrototipo.catDocumentos.strUrl;

                prototipos.Add(prototipoDM);

            }

            return prototipos;

        }

        public PrototipoDomainModel GetPrototipoById(int _idPrototipo)
        {
            PrototipoDomainModel prototipoDM = new PrototipoDomainModel();

            Expression<Func<tblPrototipo, bool>> predicate = p => p.id == _idPrototipo;
            tblPrototipo tblPrototipo = prototipoRepository.GetAll(predicate).FirstOrDefault();

            prototipoDM.id = tblPrototipo.id;
            prototipoDM.idDocumento = tblPrototipo.idDocumento.Value;
            prototipoDM.idPais = tblPrototipo.idPais.Value;
            prototipoDM.idPersonal = tblPrototipo.idPersonal.Value;
            prototipoDM.idStatsu = tblPrototipo.idStatus.Value;
            prototipoDM.strAutor = tblPrototipo.strAutor;
            prototipoDM.strCaracteristicas = tblPrototipo.strCaracteristicas;
            prototipoDM.strEstadoActual = tblPrototipo.strEstadoActual;
            prototipoDM.strInstitucionDestinada = tblPrototipo.strInstitucionDestinada;
            prototipoDM.strNombrePrototipo = tblPrototipo.strNombrePrototipo;
            prototipoDM.strObjetivos = tblPrototipo.strObjetivos;
            prototipoDM.strProposito = tblPrototipo.strProposito;
            prototipoDM.strTipoPrototipo = tblPrototipo.strTipoPrototipo;
            prototipoDM.dteFechaPublicacion = tblPrototipo.dteFechaPublicacion.Value;
            prototipoDM.bitConsideraCurriculum = tblPrototipo.bitConsideraCurriculum.Value;

            return prototipoDM;
        }

        public bool DeletePrototipoById(int _idPrototipo)
        {
            bool respueta = false;

            Expression<Func<tblPrototipo, bool>> predicate = p => p.id == _idPrototipo;

            prototipoRepository.Delete(predicate);
            respueta = true;

            return respueta;
        }
    }
}
