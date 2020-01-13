using AppDigitalCv.Repository.Infraestructure;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Repository
{
    public class InstitucionAcreditaDoctoradoRepository : BaseRepository<CatInstitucionAcreditaDoctorado>
    {
        public InstitucionAcreditaDoctoradoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        
        }
    }
}
