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
                    tblTutoria.idProgramaEductivo = tutoriasDM.idProgramaEductivo;
                    tblTutoria.strEstadoTutoria = tutoriasDM.strEstadoTutoria;
                    tblTutoria.strHoras = tutoriasDM.strHoras;
                    tblTutoria.strNombreEstudiante = tutoriasDM.strNombreEstudantes;
                    tblTutoria.strTipo = tutoriasDM.strTipo;

                    tutoriaRepository.Update(tblTutoria);
                    respuesta = true;
                }
            }
            else
            {
                tblTutoria tblTutoria = new tblTutoria();

                tblTutoria.idPersonal = tutoriasDM.idPersonal;
                tblTutoria.idProgramaEductivo = tutoriasDM.idProgramaEductivo;
                tblTutoria.strEstadoTutoria = tutoriasDM.strEstadoTutoria;
                tblTutoria.strNombreEstudiante = tutoriasDM.strNombreEstudantes;
                tblTutoria.dteFechaInicio = tutoriasDM.dteFechaInicio;
                tblTutoria.dteFechaTermino = tutoriasDM.dteFechaTermino;
                tblTutoria.strHoras = tutoriasDM.strHoras;
                tblTutoria.strTipo = tutoriasDM.strTipo;

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
                tutoriasDM.strEstadoTutoria = item.strEstadoTutoria;
                tutoriasDM.strNombreEstudantes = item.strNombreEstudiante;
                tutoriasDM.dteFechaInicio = item.dteFechaInicio;
                tutoriasDM.dteFechaTermino = item.dteFechaTermino;
                tutoriasDM.strHoras = item.strHoras;
                tutoriasDM.strTipo = item.strTipo;

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
            tutoriasDM.strEstadoTutoria = tblTutoria.strEstadoTutoria;
            tutoriasDM.strNombreEstudantes = tblTutoria.strNombreEstudiante;
            tutoriasDM.dteFechaInicio = tblTutoria.dteFechaInicio;
            tutoriasDM.dteFechaTermino = tblTutoria.dteFechaTermino;
            tutoriasDM.strTipo = tblTutoria.strTipo;
            tutoriasDM.strHoras = tblTutoria.strHoras;

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
