using AppDigitalCv.Repository.Infraestructure;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Repository
{
    public class PremiosDocenteRepository :BaseRepository<tblPremiosDocente>
    {
        public PremiosDocenteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
