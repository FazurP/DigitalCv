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
                    tblPersonalAsociaciones.dteFecha = personalAsociacionesDM.DteFecha;
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
                tblPersonalAsociaciones.dteFecha = personalAsociacionesDM.DteFecha;
                tblPersonalAsociaciones.strTipoParticipacion = personalAsociacionesDM.StrTipoParticipacion;
                var record = personalAsociacionesRepository.Insert(tblPersonalAsociaciones);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }




    }
}
