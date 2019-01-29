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
    public class EstadoSaludBusiness: IEstadoSaludBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstadoSaludRepository estadoSaludRepository;
        private readonly EnfermedadesRepository enfermedadesRepository;
        public EstadoSaludBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            estadoSaludRepository = new EstadoSaludRepository(unitOfWork);
            enfermedadesRepository = new EnfermedadesRepository(unitOfWork); 

        }

        //este metodo sirve para agregar o editar un registro de el contexto seleccionado
        public string AddUpdateEstadoSalud(EstadoSaludDomainModel estadoSaludDM)
        {
            string resultado = string.Empty;
            if (estadoSaludDM.idEnfermedadPersonal  > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblEnfermedadPersonal enfermedadPersonal = estadoSaludRepository.SingleOrDefault(p=> p.idPersonal== estadoSaludDM.idPersonal);
                if (enfermedadPersonal != null)
                {
                    enfermedadPersonal.idPersonal = estadoSaludDM.idPersonal;
                    enfermedadPersonal.idEnfermedad = estadoSaludDM.idEnfermedad;
                    enfermedadPersonal.dteFechaRegistro = DateTime.Now;
                    estadoSaludRepository.Update(enfermedadPersonal);
                    //actualizamos los datos en la base de datos.
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblEnfermedadPersonal enfermedadPersonal = new tblEnfermedadPersonal();
                enfermedadPersonal.idPersonal = estadoSaludDM.idPersonal;
                enfermedadPersonal.idEnfermedad = estadoSaludDM.idEnfermedad;
                enfermedadPersonal.dteFechaRegistro = DateTime.Now;
                var record = estadoSaludRepository.Insert(enfermedadPersonal);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }
        /// <summary>
        /// Este metodo se encarga de consultar todas las enfermedades de una persona
        /// </summary>
        /// <returns>regresa una lista de enfermedades del personal</returns>
        public List<EstadoSaludDomainModel> GetEnfermedadesPersonalById(int idPersonal)
        {
            List<EstadoSaludDomainModel> estadosSalud = new List<EstadoSaludDomainModel>();
            Expression<Func<tblEnfermedadPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            
            var lista = estadoSaludRepository.GetAll(predicado);
            foreach (var c in lista)
            {
                Expression<Func<catEnfermedad, bool>> predicadoS = p => p.idEnfermedad.Equals(c.idEnfermedad);
                catEnfermedad  catEnfermedad = enfermedadesRepository.SingleOrDefault(predicadoS);
                EstadoSaludDomainModel estadoSalud = new EstadoSaludDomainModel();
                estadoSalud.idEnfermedad = c.idEnfermedad;
                estadoSalud.idEnfermedadPersonal = c.idEnfermedadPersonal;
                estadoSalud.idPersonal = c.idPersonal;
                estadoSalud.dteFechaRegistro = c.dteFechaRegistro.Value.ToLongDateString();
                estadoSalud.NombreEnfermedad = catEnfermedad.strDescripcion;
                estadosSalud.Add(estadoSalud);
            }
            return estadosSalud;
        }

        /// <summary>
        /// Este metodo se encarga de consultar un estado de salud por el identificador de la enfermedad
        /// </summary>
        /// <param name="IdEnfermedad">identificador de la enfermedad</param>
        /// <returns>estado de salud domain model de la consulta</returns>
        public EstadoSaludDomainModel GetEnfermedadesByIdEnfermedad(int IdEnfermedad)
        {
            EstadoSaludDomainModel estadoSaludDomainModel = new EstadoSaludDomainModel();
            Expression<Func<tblEnfermedadPersonal, bool>> predicado = p => p.idEnfermedad.Equals(IdEnfermedad);
            tblEnfermedadPersonal tblEnfermedadPersonal= estadoSaludRepository.SingleOrDefault(predicado);
            if(tblEnfermedadPersonal != null)
            { 
                estadoSaludDomainModel.idEnfermedad = tblEnfermedadPersonal.idEnfermedad;
                estadoSaludDomainModel.idEnfermedadPersonal = tblEnfermedadPersonal.idEnfermedadPersonal;
                estadoSaludDomainModel.idPersonal = tblEnfermedadPersonal.idPersonal;

                estadoSaludDomainModel.NombreEnfermedad = tblEnfermedadPersonal.catEnfermedad.strDescripcion;
            }
            return estadoSaludDomainModel;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar una entidad dentro de la base de datos
        /// </summary>
        /// <param name="IdEnfermedad">el identificador de la entidad a eliminar</param>
        /// <returns>regresa un valor booleano true o false dependiendo la condición</returns>
        public bool DeleteEstadoSaludPersonal(int IdEnfermedad)
        {
            bool respuesta = false;
            Expression<Func<tblEnfermedadPersonal, bool>> predicado = p => p.idEnfermedad.Equals(IdEnfermedad);
            estadoSaludRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
            
        }



    }
}
