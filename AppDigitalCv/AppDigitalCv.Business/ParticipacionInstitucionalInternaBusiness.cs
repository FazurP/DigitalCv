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
    public class ParticipacionInstitucionalInternaBusiness : IParticipacionInstitucionalInternaBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ParticipacionInstitucionalInternaRepository participacionInstitucionalInternaRepository;
        public ParticipacionInstitucionalInternaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            participacionInstitucionalInternaRepository = new ParticipacionInstitucionalInternaRepository(unitofWork);
        }

        public bool AddUpdateParticipacion(ParticipacionInstitucionalInternaDomainModel participacionInstitucionalInternaDM)
        {

            bool respuesta = false;

            if (participacionInstitucionalInternaDM.id > 0)
            {
                tblParticipacionInstitucionalInterna participacion =
                    participacionInstitucionalInternaRepository.
                    SingleOrDefault(p => p.id == participacionInstitucionalInternaDM.id);

                if (participacion != null)
                {
                    participacion.id = participacionInstitucionalInternaDM.id;
                    participacion.idCatPeriodo = participacionInstitucionalInternaDM.idCatPeriodo;
                    participacion.idCatProgramaEducativo = participacionInstitucionalInternaDM.idCatProgramaEducativo;
                    participacion.idCatTipoActividad = participacionInstitucionalInternaDM.idCatTipoActividad;
                    participacion.strActividad = participacionInstitucionalInternaDM.strActividad;
                    participacion.fechaInicio = participacionInstitucionalInternaDM.fechaInicio;
                    participacion.fechaTermino = participacionInstitucionalInternaDM.fechaTermino;

                    participacionInstitucionalInternaRepository.Update(participacion);

                    respuesta = true;
                }

            }
            else
            {
                tblParticipacionInstitucionalInterna tblParticipacionInstitucional = new tblParticipacionInstitucionalInterna();
                tblParticipacionInstitucional.id = participacionInstitucionalInternaDM.id;
                tblParticipacionInstitucional.idCatDocumento = participacionInstitucionalInternaDM.idCatDocumento;
                tblParticipacionInstitucional.idCatPeriodo = participacionInstitucionalInternaDM.idCatPeriodo;
                tblParticipacionInstitucional.idCatProgramaEducativo = participacionInstitucionalInternaDM.idCatProgramaEducativo;
                tblParticipacionInstitucional.idCatTipoActividad = participacionInstitucionalInternaDM.idCatTipoActividad;
                tblParticipacionInstitucional.idPersonal = participacionInstitucionalInternaDM.idPersonal;
                tblParticipacionInstitucional.strActividad = participacionInstitucionalInternaDM.strActividad;
                tblParticipacionInstitucional.fechaInicio = participacionInstitucionalInternaDM.fechaInicio;
                tblParticipacionInstitucional.fechaTermino = participacionInstitucionalInternaDM.fechaTermino;

                participacionInstitucionalInternaRepository.Insert(tblParticipacionInstitucional);

                respuesta = true;
            }

            return respuesta;

        }
        public List<ParticipacionInstitucionalInternaDomainModel> GetParticipacionesPersonalesById(int id)
        {
            List<ParticipacionInstitucionalInternaDomainModel> participaciones = new List<ParticipacionInstitucionalInternaDomainModel>();
            Expression<Func<tblParticipacionInstitucionalInterna, bool>> predicate = p => p.idPersonal == id;
            List<tblParticipacionInstitucionalInterna> tblParticipaciones = participacionInstitucionalInternaRepository.GetAll(predicate).ToList();

            foreach (tblParticipacionInstitucionalInterna participacion in tblParticipaciones)
            {
                ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();

                participacionDM.id = participacion.id;
                participacionDM.idCatDocumento = participacion.idCatDocumento.Value;
                participacionDM.idCatPeriodo = participacion.idCatPeriodo.Value;
                participacionDM.idCatProgramaEducativo = participacion.idCatProgramaEducativo.Value;
                participacionDM.idCatTipoActividad = participacion.idCatTipoActividad.Value;
                participacionDM.idPersonal = participacion.idPersonal.Value;
                participacionDM.strActividad = participacion.strActividad;
                participacionDM.fechaInicio = participacion.fechaInicio.Value;
                participacionDM.fechaTermino = participacion.fechaTermino.Value;

                participaciones.Add(participacionDM);
            }

            return participaciones;

        }

        public ParticipacionInstitucionalInternaDomainModel GetParticipacion(int idPersonal, int idDocumento)
        {
            ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();

            Expression<Func<tblParticipacionInstitucionalInterna, bool>> predicante = p => p.idPersonal == idPersonal &&
             p.idCatDocumento == idDocumento;

            tblParticipacionInstitucionalInterna tblParticipacion =
                participacionInstitucionalInternaRepository.GetAll(predicante).FirstOrDefault<tblParticipacionInstitucionalInterna>();

            participacionDM.id = tblParticipacion.id;
            participacionDM.idCatDocumento = tblParticipacion.idCatDocumento.Value;
            participacionDM.idCatPeriodo = tblParticipacion.idCatPeriodo.Value;
            participacionDM.idCatProgramaEducativo = tblParticipacion.idCatProgramaEducativo.Value;
            participacionDM.idCatTipoActividad = tblParticipacion.idCatTipoActividad.Value;
            participacionDM.idPersonal = tblParticipacion.idPersonal.Value;
            participacionDM.strActividad = tblParticipacion.strActividad;
            participacionDM.fechaInicio = tblParticipacion.fechaInicio.Value;
            participacionDM.fechaTermino = tblParticipacion.fechaTermino.Value;

            return participacionDM;
        }

        public ParticipacionInstitucionalInternaDomainModel GetParticipacionEdit(int idPersonal, int idDocumento)
        {
            ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();

            Expression<Func<tblParticipacionInstitucionalInterna, bool>> predicate
                = p => p.idPersonal == idPersonal && p.idCatDocumento == idDocumento;

            tblParticipacionInstitucionalInterna tblParticipacion =
                participacionInstitucionalInternaRepository.GetAll(predicate).FirstOrDefault<tblParticipacionInstitucionalInterna>();
            participacionDM.id = tblParticipacion.id;
            participacionDM.idCatDocumento = tblParticipacion.idCatDocumento.Value;
            participacionDM.idCatPeriodo = tblParticipacion.idCatPeriodo.Value;
            participacionDM.idCatProgramaEducativo = tblParticipacion.idCatProgramaEducativo.Value;
            participacionDM.idCatTipoActividad = tblParticipacion.idCatTipoActividad.Value;
            participacionDM.idPersonal = tblParticipacion.idPersonal.Value;
            participacionDM.strActividad = tblParticipacion.strActividad;
            participacionDM.fechaInicio = tblParticipacion.fechaInicio.Value;
            participacionDM.fechaTermino = tblParticipacion.fechaTermino.Value;
            participacionDM.periodo = tblParticipacion.catPeriodo.strDescripcion;
            participacionDM.programaEducativo = tblParticipacion.catProgramaEducativo.strDescripcion;
            participacionDM.TipoActividad = tblParticipacion.catTipoActividad.strDescripcion;
            participacionDM.documento = tblParticipacion.catDocumentos.strUrl;

            return participacionDM;
        }

    }
}
