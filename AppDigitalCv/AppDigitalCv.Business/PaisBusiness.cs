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
            return null;
        }
    }
}
