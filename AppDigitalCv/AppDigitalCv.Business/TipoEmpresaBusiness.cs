using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using System.Linq.Expressions;
using AppDigitalCv.Business.Interface;

namespace AppDigitalCv.Business
{
    public class TipoEmpresaBusiness : ITipoEmpresaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TipoEmpresaRepository tipoEmpresaRepository;
        private readonly AsociacionesRepository asociacionesRepository;

        public TipoEmpresaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            tipoEmpresaRepository = new TipoEmpresaRepository(unitOfWork);
            asociacionesRepository = new AsociacionesRepository(unitOfWork);

        }

        /// <summary>
        /// Este metodo se encarga de consultar el tipo de empresa por el idAsociacion
        /// </summary>
        /// <param name="idTipoEmpresa">el identificador del tipo empresa</param>
        /// <returns>retorna una lista del tipo de empresas consultadas</returns>
        public List<TipoEmpresaDomainModel> GetTipoEmpresaByIdEmpresa(int idTipoEmpresa)
        {
            List<TipoEmpresaDomainModel> tipoEmpresas = null;
            Expression<Func<catTipoEmpresa, bool>> predicate = p => p.idTipoEmpresa.Equals(idTipoEmpresa);
            catTipoEmpresa catTipoempresa = tipoEmpresaRepository.SingleOrDefault(predicate);
            TipoEmpresaDomainModel tipoEmpresa = new TipoEmpresaDomainModel();
            tipoEmpresa.IdTipoEmpresa = catTipoempresa.idTipoEmpresa;
            tipoEmpresa.StrDescripcion = catTipoempresa.strDescripcion;
            tipoEmpresa.StrObservacion = catTipoempresa.strObservacion;
            tipoEmpresas.Add(tipoEmpresa);
            return tipoEmpresas;
        }

        /// <summary>
        /// Este emtodo se encarga de consultar unaempresa por el id de la Asociacion
        /// </summary>
        /// <param name="idAsociacion">el identificador de la asociacion</param>
        /// <returns>una lista del tipo empresa</returns>
        public List<TipoEmpresaDomainModel> GetTipoEmpresaByIdAsociacion(int idAsociacion)
        {
            List<TipoEmpresaDomainModel> tipoEmpresas = new List<TipoEmpresaDomainModel>();
            Expression<Func<catAsociaciones, bool>> predicate = p => p.idAsociacion.Equals(idAsociacion);
            catAsociaciones  asociaciones= asociacionesRepository.SingleOrDefault(predicate);

            catTipoEmpresa tipoEmpresa = asociaciones.catTipoEmpresa;
            TipoEmpresaDomainModel tipoEmpresaDomainModel = new TipoEmpresaDomainModel();
            tipoEmpresaDomainModel.IdTipoEmpresa = tipoEmpresa.idTipoEmpresa;
            tipoEmpresaDomainModel.StrDescripcion = tipoEmpresa.strDescripcion;
            tipoEmpresaDomainModel.StrObservacion = tipoEmpresa.strObservacion;
            tipoEmpresas.Add(tipoEmpresaDomainModel);
            return tipoEmpresas;

        }
    }
}
