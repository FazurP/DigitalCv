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
    public class ParticipacionInstitucionalExternaBusiness : IParticipacionInstitucionalExternaBusiness
    {

        private readonly IUnitOfWork unitofWork;
        private readonly ParticipacionInstitucionalExternaRepository participacionInstitucionalExternaRepository;
        public ParticipacionInstitucionalExternaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            participacionInstitucionalExternaRepository = new ParticipacionInstitucionalExternaRepository(unitofWork);
        }
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un objeto de una persona, en la base de datos.
        /// </summary>
        /// <param name="participacionInstitucionalExternaDM"></param>
        /// <returns>true o false</returns>
        public bool AddUpdateParticipacion(ParticipacionInstitucionalExternaDomainModel participacionInstitucionalExternaDM)
        {

            bool respuesta = false;

            if (participacionInstitucionalExternaDM.id > 0)
            {
                tblParticipacionInstitucionalExterna participacion =
                    participacionInstitucionalExternaRepository.
                    SingleOrDefault(p => p.id == participacionInstitucionalExternaDM.id);

                if (participacion != null)
                {
                    participacion.strActividad = participacionInstitucionalExternaDM.strActividad;
                    participacion.dteFechaInicio = participacionInstitucionalExternaDM.dteFechaInicio;
                    participacion.dteFechaTermino = participacionInstitucionalExternaDM.dteFechaTermino;

                    participacionInstitucionalExternaRepository.Update(participacion);

                    respuesta = true;
                }

            }
            else
            {
                tblParticipacionInstitucionalExterna tblParticipacionInstitucional = new tblParticipacionInstitucionalExterna();
                tblParticipacionInstitucional.id = participacionInstitucionalExternaDM.id;
                tblParticipacionInstitucional.idCatDocumento = participacionInstitucionalExternaDM.idCatDocumento;
                tblParticipacionInstitucional.idCatInstitucionSuperior = participacionInstitucionalExternaDM.idCatInstitucionSuperior;
                tblParticipacionInstitucional.idCatPeriodo = participacionInstitucionalExternaDM.idCatPeriodo;
                tblParticipacionInstitucional.idPersonal = participacionInstitucionalExternaDM.idPersonal;
                tblParticipacionInstitucional.strActividad = participacionInstitucionalExternaDM.strActividad;
                tblParticipacionInstitucional.dteFechaInicio = participacionInstitucionalExternaDM.dteFechaInicio;
                tblParticipacionInstitucional.dteFechaTermino = participacionInstitucionalExternaDM.dteFechaTermino;

                participacionInstitucionalExternaRepository.Insert(tblParticipacionInstitucional);

                respuesta = true;
            }

            return respuesta;

        }
        /// <summary>
        /// Este metodo se encarga de obtener una lista de objetos de una persona, de la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>una lista de objetos</returns>
        public List<ParticipacionInstitucionalExternaDomainModel> GetParticipacionesPersonalesById(int id)
        {
            List<ParticipacionInstitucionalExternaDomainModel> participaciones = new List<ParticipacionInstitucionalExternaDomainModel>();
            Expression<Func<tblParticipacionInstitucionalExterna, bool>> predicate = p => p.idPersonal == id;
            List<tblParticipacionInstitucionalExterna> tblParticipaciones = participacionInstitucionalExternaRepository.GetAll(predicate).ToList();

            foreach (tblParticipacionInstitucionalExterna participacion in tblParticipaciones)
            {
                ParticipacionInstitucionalExternaDomainModel participacionDM = new ParticipacionInstitucionalExternaDomainModel();

                participacionDM.id = participacion.id;
                participacionDM.idCatDocumento = participacion.idCatDocumento.Value;
                participacionDM.idCatInstitucionSuperior = participacion.idCatInstitucionSuperior.Value;
                participacionDM.idCatPeriodo = participacion.idCatPeriodo.Value;
                participacionDM.idPersonal = participacion.idPersonal.Value;
                participacionDM.strActividad = participacion.strActividad;
                participacionDM.dteFechaInicio = participacion.dteFechaInicio.Value;
                participacionDM.dteFechaTermino = participacion.dteFechaTermino.Value;

                participaciones.Add(participacionDM);
            }

            return participaciones;

        }
        /// <summary>
        /// Este metodo se encarga de obtener un objeto de una persona, de la base de datos.
        /// </summary>
        /// <param name="idPersonal"></param>
        /// <param name="idDocumento"></param>
        /// <returns>un objeto</returns>
        public ParticipacionInstitucionalExternaDomainModel GetParticipacion(int idPersonal, int idDocumento)
        {
            ParticipacionInstitucionalExternaDomainModel participacionDM = new ParticipacionInstitucionalExternaDomainModel();

            Expression<Func<tblParticipacionInstitucionalExterna, bool>> predicante = p => p.idPersonal == idPersonal &&
             p.idCatDocumento == idDocumento;

            tblParticipacionInstitucionalExterna tblParticipacion =
                participacionInstitucionalExternaRepository.GetAll(predicante).FirstOrDefault<tblParticipacionInstitucionalExterna>();

            participacionDM.id = tblParticipacion.id;
            participacionDM.idCatDocumento = tblParticipacion.idCatDocumento.Value;
            participacionDM.idCatInstitucionSuperior = tblParticipacion.idCatInstitucionSuperior.Value;
            participacionDM.idCatPeriodo = tblParticipacion.idCatPeriodo.Value;
            participacionDM.idPersonal = tblParticipacion.idPersonal.Value;
            participacionDM.strActividad = tblParticipacion.strActividad;
            participacionDM.dteFechaInicio = tblParticipacion.dteFechaInicio.Value;
            participacionDM.dteFechaTermino = tblParticipacion.dteFechaTermino.Value;


            return participacionDM;
        }

        public ParticipacionInstitucionalExternaDomainModel GetParticipacionEdit(int idPersonal, int idDocumento)
        {
            ParticipacionInstitucionalExternaDomainModel participacionDM = new ParticipacionInstitucionalExternaDomainModel();

            Expression<Func<tblParticipacionInstitucionalExterna, bool>> predicate
                = p => p.idPersonal == idPersonal && p.idCatDocumento == idDocumento;

            tblParticipacionInstitucionalExterna tblParticipacion = 
                participacionInstitucionalExternaRepository.GetAll(predicate).FirstOrDefault<tblParticipacionInstitucionalExterna>();
            participacionDM.id = tblParticipacion.id;
            participacionDM.institucionSuperior = tblParticipacion.catInstitucionSuperior.strDescripcion;
            participacionDM.periodo = tblParticipacion.catPeriodo.strDescripcion;
            participacionDM.documento = tblParticipacion.catDocumentos.strUrl;
            participacionDM.strActividad = tblParticipacion.strActividad;
            participacionDM.dteFechaInicio = tblParticipacion.dteFechaInicio.Value;
            participacionDM.dteFechaTermino = tblParticipacion.dteFechaTermino.Value;

            return participacionDM;
        }

        
    }
}
