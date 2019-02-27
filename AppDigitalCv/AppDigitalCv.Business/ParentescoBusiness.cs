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
    public class ParentescoBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly ParentescoRepository parentescoRepository;
        
        public ParentescoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            parentescoRepository = new ParentescoRepository(unitOfWork);
            
        }


        public List<ParentescoDomainModel> GetParentescos()
        {
            return null;
        }
    }
}
