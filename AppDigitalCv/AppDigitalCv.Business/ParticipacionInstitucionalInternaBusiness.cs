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
        private readonly DocumentosRepository documentosRepository;
        public ParticipacionInstitucionalInternaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            participacionInstitucionalInternaRepository = new ParticipacionInstitucionalInternaRepository(unitofWork);
            documentosRepository = new DocumentosRepository(unitofWork);
        }
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un objeto de una persona, en la base de datos
        /// </summary>
        /// <param name="participacionInstitucionalInternaDM"></param>
        /// <returns>true o false</returns>
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
                    participacion.idCatProgramaEducativo = participacionInstitucionalInternaDM.idCatProgramaEducativo;
                    participacion.idCatTipoActividad = participacionInstitucionalInternaDM.idCatTipoActividad;
                    participacion.strActividad = participacionInstitucionalInternaDM.strActividad;

                    participacionInstitucionalInternaRepository.Update(participacion);

                    respuesta = true;
                }

            }
            else
            {
                tblParticipacionInstitucionalInterna tblParticipacionInstitucional = new tblParticipacionInstitucionalInterna();
                catDocumentos catDocumentos = new catDocumentos();
                tblParticipacionInstitucional.id = participacionInstitucionalInternaDM.id;
                tblParticipacionInstitucional.idCatDocumento = participacionInstitucionalInternaDM.idCatDocumento;
                tblParticipacionInstitucional.idCatProgramaEducativo = participacionInstitucionalInternaDM.idCatProgramaEducativo;
                tblParticipacionInstitucional.idCatTipoActividad = participacionInstitucionalInternaDM.idCatTipoActividad;
                tblParticipacionInstitucional.idPersonal = participacionInstitucionalInternaDM.idPersonal;
                tblParticipacionInstitucional.strActividad = participacionInstitucionalInternaDM.strActividad;
                tblParticipacionInstitucional.fechaInicio = participacionInstitucionalInternaDM.fechaInicio;
                tblParticipacionInstitucional.fechaTermino = participacionInstitucionalInternaDM.fechaTermino;

                catDocumentos.tblParticipacionInstitucionalInterna.Add(tblParticipacionInstitucional);
                catDocumentos.strUrl = participacionInstitucionalInternaDM.documentos.StrUrl;
                documentosRepository.Insert(catDocumentos);
                respuesta = true;
            }

            return respuesta;

        }
        /// <summary>
        /// Este metodo se encarga de obtener una lista de objetos de una persona, desde la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>una lista con los objetos</returns>
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
                participacionDM.idCatProgramaEducativo = participacion.idCatProgramaEducativo.Value;
                participacionDM.idCatTipoActividad = participacion.idCatTipoActividad.Value;
                participacionDM.idPersonal = participacion.idPersonal.Value;
                participacionDM.strActividad = participacion.strActividad;
                participacionDM.fechaInicio = participacion.fechaInicio;
                participacionDM.fechaTermino = participacion.fechaTermino;
                participacionDM.documentos = new DocumentosDomainModel
                {
                    StrUrl = participacion.catDocumentos.strUrl
                };

                participaciones.Add(participacionDM);
            }

            return participaciones;

        }
        /// <summary>
        /// Este metodo se encarga de obtener un objeto de una participacion, de la base de datos.
        /// </summary>
        /// <param name="idPersonal"></param>
        /// <param name="idDocumento"></param>
        /// <returns>un objeto</returns>
        public ParticipacionInstitucionalInternaDomainModel GetParticipacion(int idPersonal, int idDocumento)
        {
            ParticipacionInstitucionalInternaDomainModel participacionDM = new ParticipacionInstitucionalInternaDomainModel();

            Expression<Func<tblParticipacionInstitucionalInterna, bool>> predicante = p => p.idPersonal == idPersonal &&
             p.idCatDocumento == idDocumento;

            tblParticipacionInstitucionalInterna tblParticipacion =
                participacionInstitucionalInternaRepository.GetAll(predicante).FirstOrDefault<tblParticipacionInstitucionalInterna>();

            participacionDM.id = tblParticipacion.id;
            participacionDM.idCatDocumento = tblParticipacion.idCatDocumento.Value;
            participacionDM.idCatProgramaEducativo = tblParticipacion.idCatProgramaEducativo.Value;
            participacionDM.idCatTipoActividad = tblParticipacion.idCatTipoActividad.Value;
            participacionDM.idPersonal = tblParticipacion.idPersonal.Value;
            participacionDM.strActividad = tblParticipacion.strActividad;
            participacionDM.fechaInicio = tblParticipacion.fechaInicio;
            participacionDM.fechaTermino = tblParticipacion.fechaTermino;
            participacionDM.documentos = new DocumentosDomainModel
            {
                StrUrl = tblParticipacion.catDocumentos.strUrl
            };

            return participacionDM;
        }  

    }
}
