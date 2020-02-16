using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPresentacionPonenciasBusiness
    {
        bool AddPonencia(PresentacionPonenciasDomainModel presentacionPonenciasDomainModel);
        List<PresentacionPonenciasDomainModel> GetPresentacionesPonencias(int idPersonal);
        PresentacionPonenciasDomainModel GetPresentacionPonencia(int idPonencia);
        bool DeletePresentacionPonencia(int idPonencia);
    }
}
