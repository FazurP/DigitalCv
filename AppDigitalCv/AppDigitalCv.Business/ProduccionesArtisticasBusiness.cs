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
    public class ProduccionesArtisticasBusiness : IProduccionesArtisticasBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ProduccionesArtisticasRepository produccionesArtisticasRepository;

        public ProduccionesArtisticasBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            produccionesArtisticasRepository = new ProduccionesArtisticasRepository(unitofWork);
        }

        public bool AddUpdateProduccionesArtisticas(ProduccionesArtisticasDomainModel produccionesArtisticasDM)
        {
            bool respuesta = false;

            if (produccionesArtisticasDM.id > 0)
            {

            }
            else
            {
                tblProduccionArtistica tblProduccionArtistica = new tblProduccionArtistica();

                tblProduccionArtistica.idDocumento = produccionesArtisticasDM.idDocumento;
                tblProduccionArtistica.idPais = produccionesArtisticasDM.idPais;
                tblProduccionArtistica.idPersonal = produccionesArtisticasDM.idPersonal;
                tblProduccionArtistica.idProduccionArtistica = produccionesArtisticasDM.idProduccionesArtisticas;
                tblProduccionArtistica.idStatus = produccionesArtisticasDM.idStatus;
                tblProduccionArtistica.strAutor = produccionesArtisticasDM.strAutor;
                tblProduccionArtistica.strDescripcion = produccionesArtisticasDM.strDescripcion;
                tblProduccionArtistica.strImpactoDiseño = produccionesArtisticasDM.strImpactoDiseño;
                tblProduccionArtistica.strImpactoInnovacion = produccionesArtisticasDM.strImpactoInnovacion;
                tblProduccionArtistica.strImpactoInvestigacion = produccionesArtisticasDM.strImpactoInvestigacion;
                tblProduccionArtistica.strImpactoMetodologia = produccionesArtisticasDM.strImpactoMetodologia;
                tblProduccionArtistica.strLugarPresento = produccionesArtisticasDM.strLugarPresento;
                tblProduccionArtistica.strNombreObra = produccionesArtisticasDM.strNombreObra;
                tblProduccionArtistica.strProposito = produccionesArtisticasDM.strProposito;
                tblProduccionArtistica.dteFechaPublicacion = produccionesArtisticasDM.dteFechaPublicacion;
                tblProduccionArtistica.bitConsideraCurriculum = produccionesArtisticasDM.bitLigarCurriculum;

                produccionesArtisticasRepository.Insert(tblProduccionArtistica);
                respuesta = true;

            }

            return respuesta;
        }

        public List<ProduccionesArtisticasDomainModel> GetProduccionesArtisticasByPersonal(int _idPersonal)
        {
            List<ProduccionesArtisticasDomainModel> produccionesArtisticas = new List<ProduccionesArtisticasDomainModel>();

            Expression<Func<tblProduccionArtistica, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblProduccionArtistica> tblProduccionArtisticas = produccionesArtisticasRepository.GetAll(predicate).ToList();

            foreach (tblProduccionArtistica tblProduccion in tblProduccionArtisticas)
            {
                ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();

                produccionesArtisticasDM.id = tblProduccion.id;
                produccionesArtisticasDM.idDocumento = tblProduccion.idDocumento.Value;
                produccionesArtisticasDM.idPais = tblProduccion.idPais.Value;
                produccionesArtisticasDM.idPersonal = tblProduccion.idPersonal.Value;
                produccionesArtisticasDM.idProduccionesArtisticas = tblProduccion.idProduccionArtistica.Value;
                produccionesArtisticasDM.idStatus = tblProduccion.idStatus.Value;
                produccionesArtisticasDM.strAutor = tblProduccion.strAutor;
                produccionesArtisticasDM.strDescripcion = tblProduccion.strDescripcion;
                produccionesArtisticasDM.strImpactoDiseño = tblProduccion.strImpactoDiseño;
                produccionesArtisticasDM.strImpactoInnovacion = tblProduccion.strImpactoInnovacion;
                produccionesArtisticasDM.strImpactoInvestigacion = tblProduccion.strImpactoInvestigacion;
                produccionesArtisticasDM.strImpactoMetodologia = tblProduccion.strImpactoMetodologia;
                produccionesArtisticasDM.strLugarPresento = tblProduccion.strLugarPresento;
                produccionesArtisticasDM.strNombreObra = tblProduccion.strNombreObra;
                produccionesArtisticasDM.strProposito = tblProduccion.strProposito;
                produccionesArtisticasDM.dteFechaPublicacion = tblProduccion.dteFechaPublicacion.Value;
                produccionesArtisticasDM.bitLigarCurriculum = tblProduccion.bitConsideraCurriculum.Value;

                produccionesArtisticas.Add(produccionesArtisticasDM);
            }

            return produccionesArtisticas;
        }

        public ProduccionesArtisticasDomainModel GetProduccion(int _idProduccion)
        {
            ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();

            Expression<Func<tblProduccionArtistica, bool>> predicate = p => p.id == _idProduccion;
            tblProduccionArtistica tblProduccion = produccionesArtisticasRepository.GetAll(predicate).FirstOrDefault();

            produccionesArtisticasDM.id = tblProduccion.id;
            produccionesArtisticasDM.idDocumento = tblProduccion.idDocumento.Value;
            produccionesArtisticasDM.idPais = tblProduccion.idPais.Value;
            produccionesArtisticasDM.idPersonal = tblProduccion.idPersonal.Value;
            produccionesArtisticasDM.idProduccionesArtisticas = tblProduccion.idProduccionArtistica.Value;
            produccionesArtisticasDM.idStatus = tblProduccion.idStatus.Value;
            produccionesArtisticasDM.strAutor = tblProduccion.strAutor;
            produccionesArtisticasDM.strDescripcion = tblProduccion.strDescripcion;
            produccionesArtisticasDM.strImpactoDiseño = tblProduccion.strImpactoDiseño;
            produccionesArtisticasDM.strImpactoInnovacion = tblProduccion.strImpactoInnovacion;
            produccionesArtisticasDM.strImpactoInvestigacion = tblProduccion.strImpactoInvestigacion;
            produccionesArtisticasDM.strImpactoMetodologia = tblProduccion.strImpactoMetodologia;
            produccionesArtisticasDM.strLugarPresento = tblProduccion.strLugarPresento;
            produccionesArtisticasDM.strNombreObra = tblProduccion.strNombreObra;
            produccionesArtisticasDM.strProposito = tblProduccion.strProposito;
            produccionesArtisticasDM.dteFechaPublicacion = tblProduccion.dteFechaPublicacion.Value;
            produccionesArtisticasDM.bitLigarCurriculum = tblProduccion.bitConsideraCurriculum.Value;

            return produccionesArtisticasDM;
        }
        public bool DeleteProduccion(int _idProduccion)
        {
            bool respuesta = false;

            Expression<Func<tblProduccionArtistica, bool>> predicate = p => p.id == _idProduccion;

            produccionesArtisticasRepository.Delete(predicate);

            respuesta = true;

            return respuesta;
        }
    }
}
