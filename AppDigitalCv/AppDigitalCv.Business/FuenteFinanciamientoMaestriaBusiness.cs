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
    public class FuenteFinanciamientoMaestriaBusiness : IFuenteFinanciamientoMaestriaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FuentaFinaciamientoMaestriaRepository fuenteFinanciamientoMaestriaRepository;

        public FuenteFinanciamientoMaestriaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            fuenteFinanciamientoMaestriaRepository = new FuentaFinaciamientoMaestriaRepository(unitOfWork);
        }

        public List<FuenteFinaciamientoMaestriaDomainModel> GetAllFuentesFinanciamientosMaestria()
        {
            List<FuenteFinaciamientoMaestriaDomainModel> fuenteFinaciamientoMaestriaDomainModels = new List<FuenteFinaciamientoMaestriaDomainModel>();

            List<CatFuentaFinaciamientoMaestria> catFuentaFinaciamientoMaestrias = fuenteFinanciamientoMaestriaRepository.GetAll().ToList();

            foreach (CatFuentaFinaciamientoMaestria item in catFuentaFinaciamientoMaestrias)
            {
                FuenteFinaciamientoMaestriaDomainModel fuenteFinaciamientoMaestriaDomainModel = new FuenteFinaciamientoMaestriaDomainModel();

                fuenteFinaciamientoMaestriaDomainModel.id = item.id;
                fuenteFinaciamientoMaestriaDomainModel.strDescripcion = item.strDescripcion;
                fuenteFinaciamientoMaestriaDomainModel.strValor = item.strValor;

                fuenteFinaciamientoMaestriaDomainModels.Add(fuenteFinaciamientoMaestriaDomainModel);
            }

            FuenteFinaciamientoMaestriaDomainModel fuenteFinaciamientoMaestriaDomainModel1 = new FuenteFinaciamientoMaestriaDomainModel();

            fuenteFinaciamientoMaestriaDomainModel1.id = 0;
            fuenteFinaciamientoMaestriaDomainModel1.strDescripcion = "Seleccionar";
            fuenteFinaciamientoMaestriaDomainModel1.strValor = "Seleccionar";

            fuenteFinaciamientoMaestriaDomainModels.Insert(0,fuenteFinaciamientoMaestriaDomainModel1);

            return fuenteFinaciamientoMaestriaDomainModels;
        }
    }
}
