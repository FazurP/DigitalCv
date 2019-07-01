using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IProgresoProdep
    {
        List<ProgresoProdepDomainModel> GetProgresoByPersonal(int _idPersonal);
        bool AddUpdateProgresoProdep(ProgresoProdepDomainModel progresoProdepDM);
        bool DeleteProgresoProdep(int _idProgreso);
        ProgresoProdepDomainModel GetProgresoPersonal(int _idPersonal, int _idStatus);
    }
}
