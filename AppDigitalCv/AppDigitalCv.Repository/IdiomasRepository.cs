using AppDigitalCv.Repository.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Repository.Infraestructure.Contract;

namespace AppDigitalCv.Repository
{
    public class IdiomasRepository : BaseRepository<catIdioma>
    {
        public IdiomasRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
