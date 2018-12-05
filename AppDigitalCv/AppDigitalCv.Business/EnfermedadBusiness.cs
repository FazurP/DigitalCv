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
    public class EnfermedadBusiness: IEnfermedadBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EnfermedadesRepository enfermedadesRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma

        public EnfermedadBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            enfermedadesRepository = new EnfermedadesRepository(unitOfWork);
        }

        /// <summary>
        /// este metodo se encarga de consultar todas las enfermedades
        /// </summary>
        /// <returns>regresa una lista de enfermedades</returns>
        public List<EnfermedadDomainModel> GetEnfermedades()
        {
            List<EnfermedadDomainModel> enfermedades = null;
            enfermedades = enfermedadesRepository.GetAll().Select(p => new EnfermedadDomainModel { IdEnfermedad = p.idEnfermedad, StrDescripcion = p.strDescripcion, StrObservacion = p.strObservacion }).ToList();
            return enfermedades;
        }

    }
}
