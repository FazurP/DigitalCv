using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class CursosBusiness: ICursosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CursosRepository cursosRepository;

        public CursosBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            cursosRepository = new CursosRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de agregar nuevos cursos ala tabla principal
        /// </summary>
        /// <param name="cursosDM">una entidad del tipo cursos</param>
        /// <returns>una cadena de confirmación</returns>
        public string AddUpdateCursos(CursosDomainModel cursosDM)
        {
            string resultado = string.Empty;
            DateTime dateTimeresult = DateTime.Now;
            if (cursosDM.Id > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblCursos tblCursos = cursosRepository.SingleOrDefault(p=>p.id == cursosDM.Id);
                if (tblCursos != null && !cursosDM.FechaInicio.Equals(string.Empty)  && !cursosDM.FechaTermino.Equals(string.Empty))
                {
                    tblCursos.id = cursosDM.Id;
                    tblCursos.idCurso = cursosDM.CursoDomainModel.Id;
                    tblCursos.idInstitucion = cursosDM.InstitucionSuperiorDomainModel.IdInstitucionSuperior;
                    tblCursos.idPersonal = cursosDM.IdPersonal;
                    tblCursos.dteFechaInicio = DateTime.Parse(cursosDM.FechaInicio);
                    tblCursos.dteFechaTermino = DateTime.Parse(cursosDM.FechaTermino);
                    tblCursos.strUrlDocumento = cursosDM.StrUrlDocumento;
                    cursosRepository.Update(tblCursos);
                    resultado = "Se Actualizo correctamente";
                }
            }
            else
            {
                if (!cursosDM.FechaInicio.Equals(string.Empty) && !cursosDM.FechaTermino.Equals(string.Empty))
                {
                    tblCursos tblCursos = new tblCursos();
                    tblCursos.idCurso = cursosDM.IdCurso;
                    tblCursos.idInstitucion = cursosDM.IdInstitucionSuperior;
                    tblCursos.idPersonal = cursosDM.IdPersonal;
                    tblCursos.dteFechaInicio = DateTime.Parse(cursosDM.FechaInicio);
                    tblCursos.dteFechaTermino = DateTime.Parse(cursosDM.FechaTermino);
                    tblCursos.strUrlDocumento = cursosDM.StrUrlDocumento;
                    cursosRepository.Insert(tblCursos);
                    resultado = "Se insertaron correctamente los valores";
                }
                
            }

            return resultado;
        }


        /// <summary>
        /// Este metodo se encarga de consultar los cursos personales de un personal de la institucion
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>regresa una lista de todos los cursos</returns>
        public List<CursosDomainModel> GetCursosPersonalesById(int idPersonal)
        {
            List<CursosDomainModel> cursosPersonales = new List<CursosDomainModel>();

            Expression<Func<tblCursos, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            List<tblCursos> lista = cursosRepository.GetAll(predicado).ToList<tblCursos>();

            if (lista != null)
            {
                foreach (var c in lista)
                {
                    CursoDomainModel cursoDomain = new CursoDomainModel();
                    cursoDomain.Id = c.idCurso.Value;
                    cursoDomain.StrDescripcion = c.catCurso.strDescripcion;

                    InstitucionSuperiorDomainModel institucionSuperior = new InstitucionSuperiorDomainModel();
                    institucionSuperior.IdInstitucionSuperior = c.idInstitucion.Value;
                    institucionSuperior.StrDescripcion = c.catInstitucionSuperior.strDescripcion;

                    CursosDomainModel cursosDomain = new CursosDomainModel();
                    cursosDomain.CursoDomainModel = cursoDomain;
                    cursosDomain.InstitucionSuperiorDomainModel = institucionSuperior;
                    cursosDomain.Id = c.id;
                    cursosDomain.IdPersonal = c.idPersonal.Value;
                    cursosDomain.FechaInicio = c.dteFechaInicio.Value.ToShortDateString();
                    cursosDomain.FechaTermino = c.dteFechaTermino.Value.ToShortDateString();
                    cursosDomain.IdCurso = c.idCurso.Value;
                    cursosDomain.IdInstitucionSuperior = c.idInstitucion.Value;
                    cursosDomain.StrUrlDocumento = c.strUrlDocumento;
                    cursosPersonales.Add(cursosDomain);
                    
                }
            }

            return cursosPersonales;
        }

        /// <summary>
        /// Este metodo se encarga de consultar el curso de una persona por id
        /// </summary>
        /// <param name="Id">el identificador del curso</param>
        /// <returns>una entidad del tipo cursosdomainmodel</returns>
        public CursosDomainModel GetCursoPersonalById(int Id)
        {
            CursosDomainModel cursosDomain = new CursosDomainModel();
            Expression<Func<tblCursos, bool>> predicado = p => p.id.Equals(Id);
            tblCursos  tblcurso= cursosRepository.SingleOrDefault(predicado);

            CursoDomainModel cursoDomain = new CursoDomainModel();
            cursoDomain.Id = tblcurso.catCurso.id;
            cursoDomain.StrDescripcion = tblcurso.catCurso.strDescripcion;

            InstitucionSuperiorDomainModel institucionSuperior = new InstitucionSuperiorDomainModel();
            institucionSuperior.IdInstitucionSuperior = tblcurso.catInstitucionSuperior.idInstitucionSuperior;
            institucionSuperior.StrDescripcion = tblcurso.catInstitucionSuperior.strDescripcion;

            cursosDomain.CursoDomainModel = cursoDomain;
            cursosDomain.InstitucionSuperiorDomainModel = institucionSuperior;
            cursosDomain.Id = tblcurso.id;
            cursosDomain.IdPersonal = tblcurso.idPersonal.Value;
            cursosDomain.FechaInicio = tblcurso.dteFechaInicio.Value.ToShortDateString();
            cursosDomain.FechaTermino = tblcurso.dteFechaTermino.Value.ToShortDateString();
            cursosDomain.IdCurso = tblcurso.idCurso.Value;
            cursosDomain.IdInstitucionSuperior = tblcurso.idInstitucion.Value;
            cursosDomain.StrUrlDocumento = tblcurso.strUrlDocumento;
            return cursosDomain;
        }

    }
}
