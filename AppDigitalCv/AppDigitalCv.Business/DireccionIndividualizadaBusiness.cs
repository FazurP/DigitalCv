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
                Expression<Func<tblDireccionIndividualizada, bool>> predicate = p => p.id == direccionIndividualizadaDM.id;
                tblDireccionIndividualizada tblDireccionIndividualizada = direccionIndividualizadaRepository.GetAll(predicate).FirstOrDefault();

                if (tblDireccionIndividualizada != null)
                {
                    tblDireccionIndividualizada.strTituloTesis = direccionIndividualizadaDM.strTituloTesis;
                    tblDireccionIndividualizada.strNumeroAlumnos = direccionIndividualizadaDM.strNumeroAlumnos;

                    direccionIndividualizadaRepository.Update(tblDireccionIndividualizada);

                    respuesta = true;
                }
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

        public List<DireccionIndividualizadaDomainModel> GetDireccionesByIdPersonal(int _idPersonal)
        {
            List<DireccionIndividualizadaDomainModel> direccionIndividualizadas = new List<DireccionIndividualizadaDomainModel>();

            Expression<Func<tblDireccionIndividualizada, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblDireccionIndividualizada> tblDirecciones = direccionIndividualizadaRepository.GetAll(predicate).ToList();

            foreach (tblDireccionIndividualizada item in tblDirecciones)
            {
                DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

                direccionIndividualizadaDM.id = item.id;
                direccionIndividualizadaDM.idInstitucionSuperior = item.idInstitucionSuperior.Value;
                direccionIndividualizadaDM.idPersonal = item.idPersonal.Value;
                direccionIndividualizadaDM.idStatus = item.idStatus.Value;
                direccionIndividualizadaDM.idTipoEstudio = item.idTipoEstudio.Value;
                direccionIndividualizadaDM.strEstadoDireccionIndividualizada = item.strEstadoDireccionIndividualizada;
                direccionIndividualizadaDM.strNumeroAlumnos = item.strNumeroAlumnos;
                direccionIndividualizadaDM.strTituloTesis = item.strTituloTesis;
                direccionIndividualizadaDM.dteFechaInicio = item.dteFechaInicio.Value;
                direccionIndividualizadaDM.dteFechaTermino = item.dteFechaTermino.Value;
                direccionIndividualizadaDM.bitConsideraCurriculum = item.bitConsideraCurriculum.Value;

                direccionIndividualizadas.Add(direccionIndividualizadaDM);
            }

            return direccionIndividualizadas;
        }

        public DireccionIndividualizadaDomainModel GetDireccionById(int _idDireccion)
        {
            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

            Expression<Func<tblDireccionIndividualizada, bool>> predicate = p => p.id == _idDireccion;
            tblDireccionIndividualizada tblDireccion = direccionIndividualizadaRepository.GetAll(predicate).FirstOrDefault();

            direccionIndividualizadaDM.id = tblDireccion.id;
            direccionIndividualizadaDM.idInstitucionSuperior = tblDireccion.idInstitucionSuperior.Value;
            direccionIndividualizadaDM.idPersonal = tblDireccion.idPersonal.Value;
            direccionIndividualizadaDM.idStatus = tblDireccion.idStatus.Value;
            direccionIndividualizadaDM.idTipoEstudio = tblDireccion.idTipoEstudio.Value;
            direccionIndividualizadaDM.strEstadoDireccionIndividualizada = tblDireccion.strEstadoDireccionIndividualizada;
            direccionIndividualizadaDM.strNumeroAlumnos = tblDireccion.strNumeroAlumnos;
            direccionIndividualizadaDM.strTituloTesis = tblDireccion.strTituloTesis;
            direccionIndividualizadaDM.dteFechaInicio = tblDireccion.dteFechaInicio.Value;
            direccionIndividualizadaDM.dteFechaTermino = tblDireccion.dteFechaTermino.Value;
            direccionIndividualizadaDM.bitConsideraCurriculum = tblDireccion.bitConsideraCurriculum.Value;

            return direccionIndividualizadaDM;
        }

        public bool DeleteDireccion(int _idDireccion)
        {
            bool respuesta = false;

            Expression<Func<tblDireccionIndividualizada, bool>> predicate = p => p.id == _idDireccion;

            direccionIndividualizadaRepository.Delete(predicate);

            respuesta = true;

            return respuesta;
        }
    }
}
