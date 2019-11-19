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
    public class NivelConocimientoBusiness : INivelConocimientoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly NivelConocimientoRepository nivelConocimientoRepository;

        public NivelConocimientoBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            nivelConocimientoRepository = new NivelConocimientoRepository(unitOfWork);
        }

        public List<NivelConocimientoDomainModel> GetAllNivelesConocimiento() 
        {
            List<NivelConocimientoDomainModel> nivelConocimientoDomainModels = new List<NivelConocimientoDomainModel>();
            List<CatNivelConocimiento> nivelConocimiento = new List<CatNivelConocimiento>();

            nivelConocimiento = nivelConocimientoRepository.GetAll().ToList();

            foreach (CatNivelConocimiento item in nivelConocimiento)
            {
                NivelConocimientoDomainModel nivelConocimientoDomainModel = new NivelConocimientoDomainModel();

                nivelConocimientoDomainModel.id = item.id;
                nivelConocimientoDomainModel.strValor = item.strValor;

                nivelConocimientoDomainModels.Add(nivelConocimientoDomainModel);
            }

            NivelConocimientoDomainModel nivelConocimientoDomainModel1 = new NivelConocimientoDomainModel();

            nivelConocimientoDomainModel1.id = 0;
            nivelConocimientoDomainModel1.strValor = "Seleccionar";

            nivelConocimientoDomainModels.Insert(0, nivelConocimientoDomainModel1);

            return nivelConocimientoDomainModels;
        }
    }
}
