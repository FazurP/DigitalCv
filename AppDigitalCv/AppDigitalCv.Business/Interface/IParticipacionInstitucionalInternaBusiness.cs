using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IParticipacionInstitucionalInternaBusiness
    {
        bool AddUpdateParticipacion(ParticipacionInstitucionalInternaDomainModel participacionInstitucionalInternaDM);
        List<ParticipacionInstitucionalInternaDomainModel> GetParticipacionesPersonalesById(int id);
        ParticipacionInstitucionalInternaDomainModel GetParticipacion(int idPersonal, int idDocumento);
    }
}
