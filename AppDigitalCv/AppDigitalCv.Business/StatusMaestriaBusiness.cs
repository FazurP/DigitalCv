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
    public class StatusMaestriaBusiness : IStatusMaestriaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StatusMaestriaRepository statusMaestriaRepository;

        public StatusMaestriaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            statusMaestriaRepository = new StatusMaestriaRepository(unitOfWork);
        }

        public List<StatusMaestriaDomainModel> GetAllStatusMaestrias()
        {
            List<StatusMaestriaDomainModel> statusMaestriaDomainModels = new List<StatusMaestriaDomainModel>();

            List<CatStatusMaestria> catStatusMaestrias = new List<CatStatusMaestria>();

            catStatusMaestrias = statusMaestriaRepository.GetAll().ToList();

            foreach (CatStatusMaestria item in catStatusMaestrias)
            {
                StatusMaestriaDomainModel statusMaestriaDomainModel = new StatusMaestriaDomainModel();

                statusMaestriaDomainModel.id = item.id;
                statusMaestriaDomainModel.strDescripcion = item.strDescripcion;
                statusMaestriaDomainModel.strValor = item.strValor;

                statusMaestriaDomainModels.Add(statusMaestriaDomainModel);
            }

            StatusMaestriaDomainModel statusMaestriaDomainModel1 = new StatusMaestriaDomainModel();

            statusMaestriaDomainModel1.id = 0;
            statusMaestriaDomainModel1.strDescripcion = "Seleccionar";
            statusMaestriaDomainModel1.strValor = "Seleccionar";

            statusMaestriaDomainModels.Insert(0, statusMaestriaDomainModel1);

            return statusMaestriaDomainModels;

        }
    }
}
