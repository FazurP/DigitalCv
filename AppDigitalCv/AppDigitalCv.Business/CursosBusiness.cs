using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

    }
}
