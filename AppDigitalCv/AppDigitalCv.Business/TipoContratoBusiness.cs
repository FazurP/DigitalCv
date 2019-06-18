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
    public class TipoContratoBusiness : ITipoContratoBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TipoContratoRepository tipoContratoRepository;

        public TipoContratoBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tipoContratoRepository = new TipoContratoRepository(unitofWork);
        }

        public List<TipoContratoDomainModel> GetTiposContratoById(int _id)
        {
            List<catTipoContrato> tipoContratos = new List<catTipoContrato>();
            Expression<Func<catTipoContrato, bool>> predicado = p => p.idCategoria == _id;
            tipoContratos = tipoContratoRepository.GetAll(predicado).ToList();

            List<TipoContratoDomainModel> tipoContratosDM = new List<TipoContratoDomainModel>();

            foreach (catTipoContrato item in tipoContratos)
            {
                TipoContratoDomainModel tipoContratoDM = new TipoContratoDomainModel();

                tipoContratoDM.idTipoContrato = item.idCategoria;
                tipoContratoDM.strDescripcion = item.strDescripcion;
                tipoContratoDM.strObservacion = item.strObservacion;
                tipoContratoDM.idCategoria = item.idCategoria;
                tipoContratoDM.idSalario = item.idSalario;
                tipoContratosDM.Add(tipoContratoDM);
            }

          

            return tipoContratosDM;

        }
    }
}
