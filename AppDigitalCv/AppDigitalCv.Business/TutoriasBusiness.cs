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
    public class TutoriasBusiness : ITutoriasBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TutoriasRepository tutoriaRepository;

        public TutoriasBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tutoriaRepository = new TutoriasRepository(unitofWork);
        }

        public bool AddUpdateTutorias(TutoriasDomainModel tutoriasDM)
        {
            bool respuesta = false;

            if (tutoriasDM.id > 0)
            {
                Expression<Func<tblTutoria, bool>> predicate = p => p.id == tutoriasDM.id;
                tblTutoria tblTutoria = tutoriaRepository.GetAll(predicate).FirstOrDefault();

                if (tblTutoria != null)
                {
                    tblTutoria.strNombreEstudiante = tutoriasDM.strNombreEstudantes;
                    tblTutoria.strNumeroEstudiantes = tutoriasDM.strNumeroEstudiantes;

                    tutoriaRepository.Update(tblTutoria);
                    respuesta = true;
                }
            }
            else
            {
                tblTutoria tblTutoria = new tblTutoria();

                tblTutoria.idPersonal = tutoriasDM.idPersonal;
                tblTutoria.idProgramaEductivo = tutoriasDM.idProgramaEductivo;
                tblTutoria.idStatus = tutoriasDM.idStatus;
                tblTutoria.idTipoEstudio = tutoriasDM.idTipoEstudio;
                tblTutoria.strEstadoTutoria = tutoriasDM.strEstadoTutoria;
                tblTutoria.strNombreEstudiante = tutoriasDM.strNombreEstudantes;
                tblTutoria.strNumeroEstudiantes = tutoriasDM.strNumeroEstudiantes;
                tblTutoria.strTipo = tutoriasDM.strTipo;
                tblTutoria.strTutoria = tutoriasDM.strTutoria;
                tblTutoria.dteFechaInicio = tutoriasDM.dteFechaInicio;
                tblTutoria.dteFechaTermino = tutoriasDM.dteFechaTermino;

                tutoriaRepository.Insert(tblTutoria);
                respuesta = true;
            }

            return respuesta;
        }

        public List<TutoriasDomainModel> GetAllTutoriasByIdPersonal(int _idPersonal)
        {
            List<TutoriasDomainModel> tutorias = new List<TutoriasDomainModel>();

            Expression<Func<tblTutoria, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblTutoria> tblTutorias = tutoriaRepository.GetAll(predicate).ToList();

            foreach (tblTutoria item in tblTutorias)
            {
                TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

                tutoriasDM.id = item.id;
                tutoriasDM.idPersonal = item.idPersonal.Value;
                tutoriasDM.idProgramaEductivo = item.idProgramaEductivo.Value;
                tutoriasDM.idStatus = item.idStatus.Value;
                tutoriasDM.idTipoEstudio = item.idTipoEstudio.Value;
                tutoriasDM.strEstadoTutoria = item.strEstadoTutoria;
                tutoriasDM.strNombreEstudantes = item.strNombreEstudiante;
                tutoriasDM.strNumeroEstudiantes = item.strNumeroEstudiantes;
                tutoriasDM.strTipo = item.strTipo;
                tutoriasDM.strTutoria = item.strTutoria;
                tutoriasDM.dteFechaInicio = item.dteFechaInicio.Value;
                tutoriasDM.dteFechaTermino = item.dteFechaTermino.Value;

                tutorias.Add(tutoriasDM);
            }

            return tutorias;
        }

        public TutoriasDomainModel GetTutoriaById(int _idTutoria)
        {
            Expression<Func<tblTutoria, bool>> predicate = p => p.id == _idTutoria;
            tblTutoria tblTutoria = tutoriaRepository.GetAll(predicate).FirstOrDefault();

            TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

            tutoriasDM.id = tblTutoria.id;
            tutoriasDM.idPersonal = tblTutoria.idPersonal.Value;
            tutoriasDM.idProgramaEductivo = tblTutoria.idProgramaEductivo.Value;
            tutoriasDM.idStatus = tblTutoria.idStatus.Value;
            tutoriasDM.idTipoEstudio = tblTutoria.idTipoEstudio.Value;
            tutoriasDM.strEstadoTutoria = tblTutoria.strEstadoTutoria;
            tutoriasDM.strNombreEstudantes = tblTutoria.strNombreEstudiante;
            tutoriasDM.strNumeroEstudiantes = tblTutoria.strNumeroEstudiantes;
            tutoriasDM.strTipo = tblTutoria.strTipo;
            tutoriasDM.strTutoria = tblTutoria.strTutoria;
            tutoriasDM.dteFechaInicio = tblTutoria.dteFechaInicio.Value;
            tutoriasDM.dteFechaTermino = tblTutoria.dteFechaTermino.Value;

            return tutoriasDM;
        }

        public bool DeleteTutoria(int _idTutoria)
        {
            bool respuesta = false;

            Expression<Func<tblTutoria, bool>> predicate = p => p.id == _idTutoria;

            tutoriaRepository.Delete(predicate);

            return respuesta;
        }


        
    }
}
