using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class CursoBusiness: ICursoBusiness
    {
        //Creacion de los objetos del repositorio
        private readonly IUnitOfWork unitOfWork;
        private readonly CursoRepository cursoRepository;

        public CursoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            cursoRepository = new CursoRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los cursos del catalogo correspondiente
        /// </summary>
        /// <returns>una lista de cursos consultados</returns>
        public List<CursoDomainModel> GetCursos()
        {
            List<CursoDomainModel> cursos = new List<CursoDomainModel>();
            cursos = cursoRepository.GetAll().Select(p => new CursoDomainModel { Id = p.id, StrDescripcion = p.strDescripcion }).ToList();
            cursos.Insert(0, new CursoDomainModel { Id = 0, StrDescripcion = "Seleccionar" });
            return cursos;
        }

    }
}
