using AppDigitalCv.Repository.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Repository.Infraestructure.Contract;
using AppDigitalCv.Domain;

namespace AppDigitalCv.Repository
{
    public class DialectosRepository : BaseRepository<catDialecto>
    {
        public DialectosRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
