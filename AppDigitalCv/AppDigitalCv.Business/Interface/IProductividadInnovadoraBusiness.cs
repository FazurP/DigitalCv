using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IProductividadInnovadoraBusiness
    {
        bool AddUpdateProductividadInnovador(ProductividadInnovadoraDomainModel productividadInnovadoraDomainModel);
        List<ProductividadInnovadoraDomainModel> GetProductividades(int _idPersonal);
        ProductividadInnovadoraDomainModel GetProductividad(int _idProductividad);
        bool DeleteProductividad(int _idProductividad);
    }
}
