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
    public class HobbiesBusiness : IHobbiesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly HobbiesRepository hobbiesRepository;

        public HobbiesBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            hobbiesRepository = new HobbiesRepository(unitOfWork);
        }

        public List<HobbiesDomainModel> GetAllHobbies() 
        {
            List<HobbiesDomainModel> hobbiesDomainModels = new List<HobbiesDomainModel>();
            List<CatHobbies> catHobbies = new List<CatHobbies>();

            catHobbies = hobbiesRepository.GetAll().ToList();

            foreach (CatHobbies item in catHobbies)
            {
                HobbiesDomainModel hobbiesDomainModel = new HobbiesDomainModel();

                hobbiesDomainModel.id = item.id;
                hobbiesDomainModel.strValor = item.strValor;

                hobbiesDomainModels.Add(hobbiesDomainModel);
            }

            HobbiesDomainModel hobbiesDomainModel1 = new HobbiesDomainModel();

            hobbiesDomainModel1.id = 0;
            hobbiesDomainModel1.strValor = "Seleccionar";

            hobbiesDomainModels.Insert(0, hobbiesDomainModel1);

            return hobbiesDomainModels;
        }
    }
}
