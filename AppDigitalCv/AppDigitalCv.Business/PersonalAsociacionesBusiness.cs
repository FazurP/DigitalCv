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
    public class PersonalAsociacionesBusiness: IPersonalAsociacionesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PersonalAsociacionesRepository personalAsociacionesRepository;

        public PersonalAsociacionesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            personalAsociacionesRepository = new PersonalAsociacionesRepository(unitOfWork);
        }


        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        public string AddUpdatePersonalAsociaciones(PersonalAsociacionesDomainModel personalAsociacionesDM)
        {
            string resultado = string.Empty;
            if (personalAsociacionesDM.IdAsociacion > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPersonalAsociaciones tblPersonalAsociaciones = personalAsociacionesRepository.SingleOrDefault(p=> p.idAsociacion== personalAsociacionesDM.IdAsociacion);
                if (tblPersonalAsociaciones != null)
                {
                    tblPersonalAsociaciones.idAsociacion = personalAsociacionesDM.IdAsociacion;
                    tblPersonalAsociaciones.idPersonal = personalAsociacionesDM.IdPersonal;
                    tblPersonalAsociaciones.dteFecha = DateTime.Parse( personalAsociacionesDM.DteFecha);
                    tblPersonalAsociaciones.strTipoParticipacion = personalAsociacionesDM.StrTipoParticipacion;
                    personalAsociacionesRepository.Update(tblPersonalAsociaciones);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblPersonalAsociaciones tblPersonalAsociaciones = new tblPersonalAsociaciones();
                tblPersonalAsociaciones.idAsociacion = personalAsociacionesDM.IdAsociacion;
                tblPersonalAsociaciones.idPersonal = personalAsociacionesDM.IdPersonal;
                tblPersonalAsociaciones.dteFecha = DateTime.Parse( personalAsociacionesDM.DteFecha);
                tblPersonalAsociaciones.strTipoParticipacion = personalAsociacionesDM.StrTipoParticipacion;
                var record = personalAsociacionesRepository.Insert(tblPersonalAsociaciones);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }
        
        /// <summary>
        /// este metodo sirve para agregar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        public string AddPersonalAsociaciones(PersonalAsociacionesDomainModel personalAsociacionesDM)
        {
               string resultado = string.Empty;
               tblPersonalAsociaciones tblPersonalAsociaciones = new tblPersonalAsociaciones();
               tblPersonalAsociaciones.idAsociacion = personalAsociacionesDM.IdAsociacion;
               tblPersonalAsociaciones.idPersonal = personalAsociacionesDM.IdPersonal;
               tblPersonalAsociaciones.dteFecha = DateTime.Parse(personalAsociacionesDM.DteFecha);
               tblPersonalAsociaciones.strTipoParticipacion = personalAsociacionesDM.StrTipoParticipacion;
               var record = personalAsociacionesRepository.Insert(tblPersonalAsociaciones);
               resultado = "Se insertaron correctamente los valores";
               return resultado;
        }




        /// <summary>
        /// Este metodo se encarga de obtener todas las asociaciones del personal
        /// </summary>
        /// <param name="idPersonal">el identificador de personal</param>
        /// <returns>regresa una lista de premios del tipo domain model</returns>
        public List<PersonalAsociacionesDomainModel> GetPersonalAsociacinesById(int idPersonal)
        {
            List<PersonalAsociacionesDomainModel> personalAsociacionDM = new List<PersonalAsociacionesDomainModel>();
            Expression<Func<tblPersonalAsociaciones, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            List<tblPersonalAsociaciones> pAsociacion = personalAsociacionesRepository.GetAll(predicado).ToList();

            foreach (tblPersonalAsociaciones p in pAsociacion)
            {
                PersonalAsociacionesDomainModel personalAsociacionesDomainModel = new PersonalAsociacionesDomainModel();
                personalAsociacionesDomainModel.IdAsociacion = p.idAsociacion;
                personalAsociacionesDomainModel.IdPersonal = p.idPersonal;
                personalAsociacionesDomainModel.DteFecha = p.dteFecha.ToString();
                personalAsociacionesDomainModel.StrTipoParticipacion = p.strTipoParticipacion;
                personalAsociacionDM.Add(personalAsociacionesDomainModel);
            }

            return personalAsociacionDM;

        }

        /// <summary>
        /// Este metodo se encarga de consultar una asociacion del personal en particular
        /// </summary>
        /// <param name="idAsociacion">recive el identificador de una asociacion</param>
        /// <returns>regresa una entidad personalAsociacionDomainModel</returns>
        public PersonalAsociacionesDomainModel GetPersonalAsociacionByIdAsociacion(int idAsociacion)
        {
                Expression<Func<tblPersonalAsociaciones, bool>> predicado = p => p.idAsociacion.Equals(idAsociacion);
                tblPersonalAsociaciones personalAsociaciones =personalAsociacionesRepository.SingleOrDefault(predicado);
                PersonalAsociacionesDomainModel personalAsociacionesDomainModel = new PersonalAsociacionesDomainModel();
                personalAsociacionesDomainModel.IdPersonal = personalAsociaciones.idPersonal;
                personalAsociacionesDomainModel.IdAsociacion = personalAsociaciones.idAsociacion;
                personalAsociacionesDomainModel.StrTipoParticipacion = personalAsociaciones.strTipoParticipacion;
                personalAsociacionesDomainModel.DteFecha = personalAsociaciones.dteFecha.ToString();
                return personalAsociacionesDomainModel;

        }


                                 
        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente una asociacion del docente de la base de datos
        /// </summary>
        /// <param name="personalAsociacionesDomainModel">recive una entidad del tipo personalAsociacionesDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteAsociacionDocente(PersonalAsociacionesDomainModel personalAsociacionesDomainModel)
        {
                bool respuesta = false;
                Expression<Func<tblPersonalAsociaciones, bool>> predicado = p => p.idAsociacion.Equals(personalAsociacionesDomainModel.IdAsociacion)
                && p.idPersonal.Equals(personalAsociacionesDomainModel.IdPersonal);
                personalAsociacionesRepository.Delete(predicado);
                respuesta = true;
                return respuesta;
        }




    }
}
