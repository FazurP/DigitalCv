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
        
    }
}
