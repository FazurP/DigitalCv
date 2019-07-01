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
    public class PaisBusiness : IPaisBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaisRepository paisRepository;

        public PaisBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            paisRepository = new PaisRepository(unitOfWork);
        }


        public List<PaisDomainModel> GetPais()
        {
            ///creamos la lista de paises, se encuentra vacia
            List<PaisDomainModel> paises = new List<PaisDomainModel>();
            //consultamos todos los paises y los almacenamos en la lista de paises
            paises = paisRepository.GetAll().Select(p => new PaisDomainModel { IdPais = p.id, StrValor = p.strValor }).ToList();
            PaisDomainModel paisDM = new PaisDomainModel();
            paisDM.IdPais = 0;
            paisDM.StrValor = "--Seleccionar--";
            paises.Insert(0,paisDM);
            return paises;
        }
    }
}
