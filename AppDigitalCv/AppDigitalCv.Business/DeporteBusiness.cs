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
    public class DeporteBusiness:IDeporteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DeporteRepository deporteRepository;

        public DeporteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            deporteRepository = new DeporteRepository(unitOfWork);

        }


        /// <summary>
        /// Este metodo se encarga de consultar todos los deportes posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de deportes</returns>
        public List<DeporteDomainModel> GetDeportes()
        {
            ///creamos la lista de deportes, se encuentra vacia
            List<DeporteDomainModel> parentesco = new List<DeporteDomainModel>();
            //consultamos todos los parentescos y los almacenamos en la lista de parentescos
            parentesco = deporteRepository.GetAll().Select(p => new DeporteDomainModel { IdDeporte = p.idDeporte, StrDescripcion = p.strDescripcion }).ToList();
            parentesco.Insert(0, new DeporteDomainModel { IdDeporte = 0, StrDescripcion = "Seleccionar" });
            return parentesco;
        }

        /// <summary>
        /// Este metodo se encarga de agregar una entidad del tipo catdeporte
        /// </summary>
        /// <param name="deporteDM">entidad que se va agregar al modelo de base de datos</param>
        /// <returns>un valor booleano</returns>
        public bool AddUpdateCompetenciaTi(DeporteDomainModel deporteDM)
        {
            bool respuesta = false;
            catDeporte catDeporte = new catDeporte();
            catDeporte.strDescripcion = deporteDM.StrDescripcion;
            catDeporte.strObservacion = deporteDM.StrObservacion;
            deporteRepository.Insert(catDeporte);
            respuesta = true;
            return respuesta;
        }

    }
}
