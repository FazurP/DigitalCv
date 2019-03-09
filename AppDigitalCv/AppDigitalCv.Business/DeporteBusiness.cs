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

    }
}
