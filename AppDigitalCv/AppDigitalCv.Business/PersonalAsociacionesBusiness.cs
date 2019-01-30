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


    }
}
