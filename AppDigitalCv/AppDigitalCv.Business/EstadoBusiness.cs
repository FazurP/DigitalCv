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
    public class EstadoBusiness : IEstadoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstadoRepository estadoRepository;

        public EstadoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            estadoRepository = new EstadoRepository(unitOfWork);
        }


        public List<EstadoDomainModel> GetEstado()
        {
            return null;
        }

        /// <summary>
        /// este metodo se encarga de consultar estados por el id del páis
        /// </summary>
        /// <param name="idPais">recibe el id del pais</param>
        /// <returns>regresa una lista de estados que pertenecen a un pais</returns>
        public List<EstadoDomainModel> GetEstadoByIdPais(int idPais)
        {
            List<CatEstado> catEstados = null;
            Expression<Func<CatEstado, bool>> predicado = p => p.idPais.Equals(idPais);

            List<EstadoDomainModel> estadosDM = new List<EstadoDomainModel>();
            catEstados = estadoRepository.GetAll(predicado).ToList();

            foreach (CatEstado estados in catEstados)
            {
                EstadoDomainModel estadoDM = new EstadoDomainModel();
                estadoDM.id = estados.id;
                estadoDM.strValor = estados.strValor;
                estadoDM.idPais = estados.idPais;
                estadosDM.Add(estadoDM);
            }
            return estadosDM;
        }
    }
}
