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
    public class EdificioBusiness : IEdificioBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly EdificioRepository edificioRepository;

        public EdificioBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            edificioRepository = new EdificioRepository(unitofWork);
        }

        public List<EdificioDomainModel> getEdificios() 
        {

            List<EdificioDomainModel> edificios = new List<EdificioDomainModel>();
            edificios = edificioRepository.GetAll().Select(p => new EdificioDomainModel
            {
                idEdificio = p.idEdificio,
                strDescripcion = p.strDescripcion,
                strObservacion = p.strObservacion
            }).ToList<EdificioDomainModel>();
            EdificioDomainModel edificioDM = new EdificioDomainModel();
            edificioDM.idEdificio = 0;
            edificioDM.strDescripcion = "--Seleccionar--";
            edificios.Insert(0,edificioDM);
            return edificios;

        }
    }
}
