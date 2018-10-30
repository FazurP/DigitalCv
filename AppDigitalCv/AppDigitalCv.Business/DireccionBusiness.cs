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
    public class DireccionBusiness :IDireccionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaisRepository paisRepository;
        private readonly EstadoRepository estadoRepository;

        public DireccionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            paisRepository = new PaisRepository(unitOfWork);
            estadoRepository = new EstadoRepository(unitOfWork);
        }

        //Metodo para obtener los paises 
        public List<PaisDomainModel> GetPais()
        {
          ///creamos la lista de paises, se encuentra vacia
          List<PaisDomainModel> paises = null;
          //consultamos todos los paises y los almacenamos en la lista de paises
          paises = paisRepository.GetAll().Select(p => new PaisDomainModel { IdPais = p.id, StrValor = p.strValor }).ToList();
          return paises;
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
