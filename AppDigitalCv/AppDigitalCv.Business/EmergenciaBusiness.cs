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
            if (emergenciaDM.IdEmergencia > 0)
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
                //tblEmergencia.idEmergencia = emergenciaDM.IdEmergencia;
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
        /// <summary>
        /// Este metodo se encarga de consultar los los datos de conatcto de emergencia 
        /// </summary>
        /// <param name="idPersonal">recive el identificador de la emergencia del personal</param>
        /// <returns>regresa una lista de los Emergencia en la entidad domain model</returns>
        public List<EmergenciaDomianModel> GetEmergenciasById(int idPersonal)
        {
            List<EmergenciaDomianModel> emergencias = new List<EmergenciaDomianModel>();
            Expression<Func<tblEmergencia, bool>> predicado = p => p.idPersonal.Equals(idPersonal);

            List<tblEmergencia> Emergencias = emergenciaRepository.GetAll(predicado).ToList<tblEmergencia>();

            foreach (tblEmergencia tblemergencias in Emergencias)
            {
                EmergenciaDomianModel emergenciaDM = new EmergenciaDomianModel();
                emergenciaDM.IdEmergencia = tblemergencias.idEmergencia;
                emergenciaDM.IdPersonal = tblemergencias.idPersonal;
                emergenciaDM.StrNombre = tblemergencias.strNombre;
                emergenciaDM.StrDireccion = tblemergencias.strDireccion;
                emergenciaDM.StrTelefono = tblemergencias.strTelefono;
                emergencias.Add(emergenciaDM);
            }

            return emergencias;

        }
        /// <summary>
        /// Este metodo se encarga de consultar los los datos de conatcto de emergencia 
        /// </summary>
        /// <param name="idPersonal">recibe el identificador de la emergencia del personal</param>
        /// <returns>regresa una entidad de  Emergencia Domain Model</returns>
        public EmergenciaDomianModel GetEmergenciaById(int idEmergencia)
        {
            Expression<Func<tblEmergencia, bool>> predicado = p => p.idEmergencia.Equals(idEmergencia);
            tblEmergencia Emergencias = emergenciaRepository.SingleOrDefault(predicado);
            EmergenciaDomianModel emergenciaDM = new EmergenciaDomianModel();
            emergenciaDM.IdEmergencia = Emergencias.idEmergencia;
            emergenciaDM.IdParentesco = Emergencias.idParentesco;
            emergenciaDM.IdPersonal = Emergencias.idPersonal;
            emergenciaDM.StrNombre = Emergencias.strNombre;
            emergenciaDM.StrDireccion = Emergencias.strDireccion;
            emergenciaDM.StrTelefono = Emergencias.strTelefono;
            return emergenciaDM;
        }







    }
}
