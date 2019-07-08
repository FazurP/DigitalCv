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
    public class ProductividadInnovadoraBusiness : IProductividadInnovadoraBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProduccionInnovadoraRepository produccionInnovadoraRepository;
        public ProductividadInnovadoraBusiness(IUnitOfWork _unitofWork)
        {
            unitOfWork = _unitofWork;
            produccionInnovadoraRepository = new ProduccionInnovadoraRepository(unitOfWork);
        }
    }
}
