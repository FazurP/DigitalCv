using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface ITutoriasBusiness
    {
        bool AddUpdateTutorias(TutoriasDomainModel tutoriasDM);
        List<TutoriasDomainModel> GetAllTutoriasByIdPersonal(int _idPersonal);
        TutoriasDomainModel GetTutoriaById(int _idTutoria);

    }
}
