using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IParticipacionInstitucionalExternaBusiness
    {
        bool AddUpdateParticipacion(ParticipacionInstitucionalExternaDomainModel participacionInstitucionalExternaDM);
        List<ParticipacionInstitucionalExternaDomainModel> GetParticipacionesPersonalesById(int id);
        ParticipacionInstitucionalExternaDomainModel GetParticipacion(int idPersonal, int idDocumento);

    }
}
