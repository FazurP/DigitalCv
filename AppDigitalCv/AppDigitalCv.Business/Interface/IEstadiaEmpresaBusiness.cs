using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IEstadiaEmpresaBusiness
    {
        bool AddUpdateEstadiaEmpresa(EstadiaEmpresaDomainModel estadiaEmpresaDM);

        List<EstadiaEmpresaDomainModel> GetAllEstadiaEmpresaByIdPersonal(int _idPersonal);

        EstadiaEmpresaDomainModel GetEstadiaEmpresaById(int _idEstadia);

        bool DeleteEstadia(int _idEstadia);
    }
}
