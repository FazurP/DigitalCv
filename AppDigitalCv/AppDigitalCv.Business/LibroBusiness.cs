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
    public class LibroBusiness : ILibroBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly LibroRepository libroRepository;

        public LibroBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            libroRepository = new LibroRepository(unitofWork);
        }
    }
}
