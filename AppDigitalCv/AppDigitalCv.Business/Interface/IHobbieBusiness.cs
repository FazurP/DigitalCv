using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IHobbieBusiness
    {
        bool AddUpdateHobbie(HobbieDomainModel hobbieDomainModel);
        List<HobbieDomainModel> GetAllHobbiesByPersonal(int _idPersonal);
        HobbieDomainModel GetHobbieByPersonal(int _id);
        bool DeleteHobbie(int _id);
    }
}
