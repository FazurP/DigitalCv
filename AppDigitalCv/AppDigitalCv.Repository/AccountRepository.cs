using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Repository.Infraestructure;
using AppDigitalCv.Repository.Infraestructure.Contract;

namespace AppDigitalCv.Repository
{
    public class AccountRepository : BaseRepository<catUsuarios>
    {
        public AccountRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
