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
    public class CursoBusiness : ICursoBusiness
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


        /// <summary>
        /// Este metodo se ecarga de insertar o actualizar una entidad del tipo curso
        /// </summary>
        /// <param name="cursoDM">Entidad del tipo CursoDomainModel</param>
        /// <returns>una cadena de confirmación</returns>
        public string AddUpdateCurso(CursoDomainModel cursoDM)
        {
            string resultado = string.Empty;
            if (cursoDM.Id > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                catCurso catCurso = cursoRepository.SingleOrDefault(p => p.id == cursoDM.Id);
                if (catCurso != null)
                {
                    catCurso.id = cursoDM.Id;
                    catCurso.strDescripcion = cursoDM.StrDescripcion;
                    cursoRepository.Update(catCurso);
                    resultado = "Se Actualizo correctamente";
                }
            }
            else
            {
                catCurso Curso = new catCurso();
                Curso.strDescripcion = cursoDM.StrDescripcion;
                cursoRepository.Insert(Curso);
                resultado = "Se insertaron correctamente los valores";
            }

            return resultado;
        }
    }
}
