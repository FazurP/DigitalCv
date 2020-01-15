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
    public class FuenteFinaciamientoDoctoradoBusiness : IFuenteFinaciamientoDoctoradoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FuenteFinaciamientoDoctoradoRepository fuenteFinaciamientoDoctoradoRepository;

        public FuenteFinaciamientoDoctoradoBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;

            fuenteFinaciamientoDoctoradoRepository = new FuenteFinaciamientoDoctoradoRepository(unitOfWork);
        }

        public List<FuenteFinanciamientoDoctoradoDomainModel> GetAllFuentesFinaciamientosDoctorados() 
        {
            List<FuenteFinanciamientoDoctoradoDomainModel> fuenteFinanciamientoDoctoradoDomainModels = new List<FuenteFinanciamientoDoctoradoDomainModel>();
            List<CatFuenteFinanciamientoDoctorado> catFuenteFinanciamientoDoctorados = new List<CatFuenteFinanciamientoDoctorado>();

            catFuenteFinanciamientoDoctorados = fuenteFinaciamientoDoctoradoRepository.GetAll().ToList();

            foreach (CatFuenteFinanciamientoDoctorado item in catFuenteFinanciamientoDoctorados)
            {
                FuenteFinanciamientoDoctoradoDomainModel fuenteFinanciamientoDoctoradoDomainModel = new FuenteFinanciamientoDoctoradoDomainModel();

                fuenteFinanciamientoDoctoradoDomainModel.id = item.id;
                fuenteFinanciamientoDoctoradoDomainModel.strDescripcion = item.strDescripcion;
                fuenteFinanciamientoDoctoradoDomainModel.strValor = item.strValor;

                fuenteFinanciamientoDoctoradoDomainModels.Add(fuenteFinanciamientoDoctoradoDomainModel);
            }

            FuenteFinanciamientoDoctoradoDomainModel fuenteFinanciamientoDoctoradoDomainModel1 = new FuenteFinanciamientoDoctoradoDomainModel();

            fuenteFinanciamientoDoctoradoDomainModel1.id = 0;
            fuenteFinanciamientoDoctoradoDomainModel1.strDescripcion = "Seleccionar";
            fuenteFinanciamientoDoctoradoDomainModel1.strValor = "Seleccionar";

            fuenteFinanciamientoDoctoradoDomainModels.Insert(0, fuenteFinanciamientoDoctoradoDomainModel1);

            return fuenteFinanciamientoDoctoradoDomainModels;
        }
    }
}
