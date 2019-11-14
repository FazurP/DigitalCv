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
    public class HobbieBusiness : IHobbieBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly HobbieRepository hobbieRepository;

        public HobbieBusiness(IUnitOfWork _unitOfWork)  
        {
            unitOfWork = _unitOfWork;
            hobbieRepository = new HobbieRepository(unitOfWork);
        }

        public bool AddUpdateHobbie(HobbieDomainModel hobbieDomainModel) 
        {
            bool respuesta = false;

            if (hobbieDomainModel.id > 0)
            {
                tblHobbies tblHobbies = hobbieRepository.GetAll(p => p.id == hobbieDomainModel.id).FirstOrDefault();

                if (tblHobbies.tblPersonal != null)
                {
                    tblHobbies.idFruencia = hobbieDomainModel.idFrecuencia;
                    tblHobbies.idHobbie = hobbieDomainModel.idHobbie;
                    tblHobbies.idPersonal = hobbieDomainModel.idPersonal;
                    tblHobbies.strTiempoPractica = hobbieDomainModel.strTiempoPractica;

                    hobbieRepository.Update(tblHobbies);
                    respuesta = true;
                }
            }
            else 
            {
                tblHobbies tblHobbies = new tblHobbies();

                tblHobbies.idFruencia = hobbieDomainModel.idFrecuencia;
                tblHobbies.idHobbie = hobbieDomainModel.idHobbie;
                tblHobbies.idPersonal = hobbieDomainModel.idPersonal;
                tblHobbies.strTiempoPractica = hobbieDomainModel.strTiempoPractica;

                hobbieRepository.Insert(tblHobbies);
                respuesta = true;
            }

            return respuesta;
        }

        public List<HobbieDomainModel> GetAllHobbiesByPersonal(int _idPersonal) 
        {
            List<HobbieDomainModel> hobbies = new List<HobbieDomainModel>();
            List<tblHobbies> tblhobbies = new List<tblHobbies>();

            tblhobbies = hobbieRepository.GetAll(p => p.idPersonal == _idPersonal).ToList();

            foreach (tblHobbies item in tblhobbies)
            {
                HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();

                hobbieDomainModel.id = item.id;
                hobbieDomainModel.idFrecuencia = item.idFruencia.Value;
                hobbieDomainModel.idHobbie = item.idHobbie.Value;
                hobbieDomainModel.idPersonal = item.idPersonal.Value;
                hobbieDomainModel.strTiempoPractica = item.strTiempoPractica;
                hobbieDomainModel.catHobbies = new HobbiesDomainModel { strValor = item.CatHobbies.strValor};

                hobbies.Add(hobbieDomainModel);
            }

            return hobbies;
        }

        public HobbieDomainModel GetHobbieByPersonal(int _id) 
        {
            HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();
            tblHobbies tblHobbies = new tblHobbies();

            tblHobbies = hobbieRepository.GetAll(p => p.id == _id).FirstOrDefault();

            if (tblHobbies != null)
            {
                hobbieDomainModel.id = tblHobbies.id;
                hobbieDomainModel.idFrecuencia = tblHobbies.idFruencia.Value;
                hobbieDomainModel.idHobbie = tblHobbies.idHobbie.Value;
                hobbieDomainModel.idPersonal = tblHobbies.idPersonal.Value;
                hobbieDomainModel.strTiempoPractica = tblHobbies.strTiempoPractica;
            }


            return hobbieDomainModel;
        }

        public bool DeleteHobbie(int _id) 
        {

            bool respuesta = false;

            if (_id > 0)
            {
                hobbieRepository.Delete(p => p.id == _id);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
