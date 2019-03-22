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
    public class FrecuenciaBusiness:IFrecuenciaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FrecuenciaRepository frecuenciaRepository;

        public FrecuenciaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            frecuenciaRepository = new FrecuenciaRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos la Frecuencia con la que se realizan actividades posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de Frecuencias</returns>
        public List<FrecuenciaDomainModel> GetFrecuencia()
        {
            ///creamos la lista de deportes, se encuentra vacia
            List<FrecuenciaDomainModel> frecuencia = new List<FrecuenciaDomainModel>();
            //consultamos todos los parentescos y los almacenamos en la lista de parentescos
            frecuencia = frecuenciaRepository.GetAll().Select(p => new FrecuenciaDomainModel { IdFrecuencia = p.idFrecuencia, StrDescripcion = p.strDescripcion }).ToList();
            frecuencia.Insert(0, new FrecuenciaDomainModel { IdFrecuencia = 0, StrDescripcion = "Seleccionar" });
            return frecuencia;
        }

    }
}
