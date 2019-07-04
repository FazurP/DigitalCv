using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class ManualOperacionBusiness : IManualOperacionBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ManualOperacionRepository manualOperacionRepository;
        public ManualOperacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            manualOperacionRepository = new ManualOperacionRepository(unitofWork);
        }
    }
}
