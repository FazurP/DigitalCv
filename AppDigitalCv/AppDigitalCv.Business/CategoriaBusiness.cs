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
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CategoriaRepository categoriaRepository;

        public CategoriaBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            categoriaRepository = new CategoriaRepository(unitOfWork);

        }

        public List<CategoriaDomainModel> GetCategorias()
        {
            List<CategoriaDomainModel> categorias = new List<CategoriaDomainModel>();
            categorias = categoriaRepository.GetAll().Select(p => new CategoriaDomainModel
            {
                idCategoria = p.idCategoria,
                strDescripcion = p.strDescripcion,
                strObservacion = p.strObservacion
            }).ToList<CategoriaDomainModel>();
            CategoriaDomainModel categoriaDM = new CategoriaDomainModel();
            categoriaDM.idCategoria = 0;
            categoriaDM.strDescripcion = "--Seleccionar--";
            categorias.Insert(0,categoriaDM);

            return categorias;
        } 

       
    }
}
