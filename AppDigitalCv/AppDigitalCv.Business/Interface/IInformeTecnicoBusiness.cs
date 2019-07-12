using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IInformeTecnicoBusiness
    {
        bool AddUpdateInformeTecnico(InformeTecnicoDomainModel informeTecnicoDomainModel);
        List<InformeTecnicoDomainModel> GetInformesByUsuario(int _idPersonal);
        InformeTecnicoDomainModel GetInformeTecnico(int _idInforme);
        bool DeleteInformeTecnico(int _idInforme);
    }
}
