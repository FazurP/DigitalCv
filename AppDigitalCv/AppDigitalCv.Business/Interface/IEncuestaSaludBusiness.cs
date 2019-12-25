using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEncuestaSaludBusiness
    {
        List<OpcionesRespuesta04DomainModel> GetAllOpcionesRespuesta04();
        List<RhDomainModel> GetAllRhs();
        List<GrupoSanguineoDomainModel> GetAllGruposSanguineos();
        bool AddEncuesta(EncuestaDomainModel encuestaDomainModel);
    }
}
