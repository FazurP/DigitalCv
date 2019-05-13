using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IAlergiasBusiness
    {
        List<AlergiasDomainModel> GetAlergias();
        List<AlergiasDomainModel> GetAlergenos();
        List<AlergiasDomainModel> GetMedicamentos();
        bool AddUpdateAlergias(AlergiasPersonalDomainModel alergiasPersonalDomainModel);
        AlergiasDomainModel GetAlergia(int idAlergia, int idPersona);


    }
}
