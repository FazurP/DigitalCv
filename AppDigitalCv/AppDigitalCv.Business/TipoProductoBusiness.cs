using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class TipoProductoBusiness : ITipoProductoBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TipoProductoRepository tipoProductoRepository;

        public TipoProductoBusiness(IUnitOfWork _unitOfWork) 
        {
            unitofWork = _unitOfWork;
            tipoProductoRepository = new TipoProductoRepository(unitofWork);
        }

        public List<TipoProductoDomainModel> GetAllTipoProducto()
        {
            List<TipoProductoDomainModel> tipoProductos = new List<TipoProductoDomainModel>();

            List<catTipoProducto> catTipoProductos = new List<catTipoProducto>();

            catTipoProductos = tipoProductoRepository.GetAll().ToList();

            foreach (catTipoProducto item in catTipoProductos)
            {
                TipoProductoDomainModel tipoProductoDM = new TipoProductoDomainModel();

                tipoProductoDM.id = item.id;
                tipoProductoDM.strDescripcion = item.strDescripcion;

                tipoProductos.Add(tipoProductoDM);
            }

            return tipoProductos;
        }
    }
}
