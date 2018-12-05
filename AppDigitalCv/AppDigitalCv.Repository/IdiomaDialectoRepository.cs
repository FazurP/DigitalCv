using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Repository.Infraestructure.Contract;

namespace AppDigitalCv.Domain
{
    public class IdiomaDialectoRepository : BaseRepository<tblIdiomaDialectoPersonal>
    {
        public IdiomaDialectoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
