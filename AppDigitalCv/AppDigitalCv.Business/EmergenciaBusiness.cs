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
    public class EmergenciaBusiness : IEmergenciaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmergenciaRepository emergenciaRepository;

        public EmergenciaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            emergenciaRepository = new EmergenciaRepository(unitOfWork);
        }

        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="emergenciaDM">recibe una entidad del tipo de emergencia domain model</param>
        /// <returns>una cadena de confirmación de inserción</returns>
        public string AddUpdateEmergencia(EmergenciaDomianModel emergenciaDM)
        {
            string resultado = string.Empty;
            if (emergenciaDM.IdPersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblEmergencia Emergencia = emergenciaRepository.SingleOrDefault(p=> p.idEmergencia == emergenciaDM.IdEmergencia);
                
                if (Emergencia != null)
                {
                    Emergencia.idEmergencia = emergenciaDM.IdEmergencia;
                    Emergencia.idParentesco = emergenciaDM.IdParentesco;
                    Emergencia.idPersonal = emergenciaDM.IdPersonal;
                    Emergencia.strDireccion = emergenciaDM.StrDireccion;
                    Emergencia.strNombre = emergenciaDM.StrNombre;
                    Emergencia.strTelefono = emergenciaDM.StrTelefono;
                    //actualizamos los datos en la base de datos.
                    emergenciaRepository.Update(Emergencia);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblEmergencia tblEmergencia = new tblEmergencia();
                tblEmergencia.idEmergencia = emergenciaDM.IdEmergencia;
                tblEmergencia.idParentesco = emergenciaDM.IdParentesco;
                tblEmergencia.idPersonal = emergenciaDM.IdPersonal;
                tblEmergencia.strNombre = emergenciaDM.StrNombre;
                tblEmergencia.strTelefono = emergenciaDM.StrTelefono;
                tblEmergencia.strDireccion = emergenciaDM.StrDireccion;
                emergenciaRepository.Insert(tblEmergencia);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }



        /// <summary>
        /// Este metodo se encarga de eliminar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="IdEmergencia">el identificador de la entidad a eliminar</param>
        /// <returns>regresa un valor booleano true o false dependiendo la condición</returns>
        public bool DeleteContactoEmergencia(int IdEmergencia)
        {
            bool respuesta = false;
            Expression<Func<tblEmergencia, bool>> predicado = p => p.idEmergencia.Equals(IdEmergencia);
            emergenciaRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }


    }
}
