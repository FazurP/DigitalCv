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
    public class StatusDoctoradoBusiness : IStatusDoctoradoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StatusDoctoradoRepository statusDoctoradoRepository;

        public StatusDoctoradoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            statusDoctoradoRepository = new StatusDoctoradoRepository(unitOfWork);
        }

        public List<StatusDoctoradoDomainModel> GetAllStatusDoctorados() 
        {
            List<StatusDoctoradoDomainModel> statusDoctoradoDomainModels = new List<StatusDoctoradoDomainModel>();

            List<CatStatusDoctorado> catStatusDoctorados = new List<CatStatusDoctorado>();

            catStatusDoctorados = statusDoctoradoRepository.GetAll().ToList();

            foreach (CatStatusDoctorado item in catStatusDoctorados)
            {
                StatusDoctoradoDomainModel statusDoctoradoDomainModel = new StatusDoctoradoDomainModel();

                statusDoctoradoDomainModel.id = item.id;
                statusDoctoradoDomainModel.strDescripcion = item.strDescripcion;
                statusDoctoradoDomainModel.strValor = item.strValor;

                statusDoctoradoDomainModels.Add(statusDoctoradoDomainModel);
            }

            StatusDoctoradoDomainModel statusDoctoradoDomainModel1 = new StatusDoctoradoDomainModel();

            statusDoctoradoDomainModel1.id = 0;
            statusDoctoradoDomainModel1.strDescripcion = "Seleccionar";
            statusDoctoradoDomainModel1.strValor = "Seleccionar";

            statusDoctoradoDomainModels.Insert(0,statusDoctoradoDomainModel1);

            return statusDoctoradoDomainModels;
        }

    }
}
