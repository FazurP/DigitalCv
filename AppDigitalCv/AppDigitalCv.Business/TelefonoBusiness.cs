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
    public class TelefonoBusiness: ITelefono
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TelefonoRepository telefonoRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma
        

        /// <summary>
        /// Este es el constructor de la clase el cual recibe la unidad principal de trabajo
        /// </summary>
        /// <param name="_unitOfWork">unidad de trabajo principal</param>
        public TelefonoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            telefonoRepository = new TelefonoRepository(unitOfWork);
            
        }

        /// <summary>
        /// Este metodo se encarga de agregar  una entidad en la base de datos
        /// </summary>
        /// <param name="datosContactoDM">la entidad que se va a ingresar en la base de datos</param>
        /// <returns>regresa un valor booleano</returns>
        public bool AddUpdateTelefono(DatosContactoDomainModel datosContactoDM)
        {
            bool respuesta = false;
            
            if (datosContactoDM.IdTelefono > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblTelefono datosContacto = telefonoRepository.SingleOrDefault(p => p.idTelefono == datosContactoDM.IdTelefono);
                
                if (datosContacto != null)
                {
                    datosContacto.idPersonal = datosContactoDM.IdPersonal;
                    datosContacto.idTelefono = datosContactoDM.IdTelefono;
                    datosContacto.strTelefonoCasa = datosContactoDM.TelefonoCasa;
                    datosContacto.strTelefonoCelular = datosContactoDM.TelefonoCelular;
                    datosContacto.strTelefonoRecados = datosContactoDM.TelefonoRecados;
                    //datosContacto.tblPersonal = personal;
                    //actualizamos los datos en la base de datos.
                    telefonoRepository.Update(datosContacto);
                    respuesta = true;

                }
            }
            else
            {
                tblTelefono tblTelefono = new tblTelefono();
                tblTelefono.strTelefonoCasa = datosContactoDM.TelefonoCasa;
                tblTelefono.strTelefonoCelular = datosContactoDM.TelefonoCelular;
                tblTelefono.strTelefonoRecados = datosContactoDM.TelefonoRecados;
                tblTelefono.idPersonal = datosContactoDM.IdPersonal;
                telefonoRepository.Insert(tblTelefono);
                respuesta = true;
            }
            return respuesta;
        }


    }
}
