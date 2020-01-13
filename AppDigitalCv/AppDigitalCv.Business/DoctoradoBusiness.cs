using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class DoctoradoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DoctoradoRepository doctoradoRepository;

        public DoctoradoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            doctoradoRepository = new DoctoradoRepository(unitOfWork);
        }
    }
}
