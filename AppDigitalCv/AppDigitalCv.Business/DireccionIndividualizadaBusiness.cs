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
    public class DireccionIndividualizadaBusiness : IDireccionIndividualizadaBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly DireccionIndividualizadaRepository direccionIndividualizadaRepository;

        public DireccionIndividualizadaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            direccionIndividualizadaRepository = new DireccionIndividualizadaRepository(unitofWork);
        }

        public bool AddUpdateDireccionIndividualizada(DireccionIndividualizadaDomainModel direccionIndividualizadaDM)
        {
            bool respuesta = false;

            if (direccionIndividualizadaDM.id > 0)
            {

            }
            else
            {
                tblDireccionIndividualizada tblDireccionIndividualizada = new tblDireccionIndividualizada();

                tblDireccionIndividualizada.idInstitucionSuperior = direccionIndividualizadaDM.idInstitucionSuperior;
                tblDireccionIndividualizada.idPersonal = direccionIndividualizadaDM.idPersonal;
                tblDireccionIndividualizada.idStatus = direccionIndividualizadaDM.idStatus;
                tblDireccionIndividualizada.idTipoEstudio = direccionIndividualizadaDM.idTipoEstudio;
                tblDireccionIndividualizada.strEstadoDireccionIndividualizada = direccionIndividualizadaDM.strEstadoDireccionIndividualizada;
                tblDireccionIndividualizada.strNumeroAlumnos = direccionIndividualizadaDM.strNumeroAlumnos;
                tblDireccionIndividualizada.strTituloTesis = direccionIndividualizadaDM.strTituloTesis;
                tblDireccionIndividualizada.dteFechaInicio = direccionIndividualizadaDM.dteFechaInicio;
                tblDireccionIndividualizada.dteFechaTermino = direccionIndividualizadaDM.dteFechaTermino;
                tblDireccionIndividualizada.bitConsideraCurriculum = direccionIndividualizadaDM.bitConsideraCurriculum;

                direccionIndividualizadaRepository.Insert(tblDireccionIndividualizada);
                respuesta = true;
            }
            return respuesta;
        }
    }
}
