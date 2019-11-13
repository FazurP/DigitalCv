using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Repository;
using AppDigitalCv.Domain;
using AppDigitalCv.Business.Interface;

namespace AppDigitalCv.Business
{
    public class AsosiacionesBusiness: IAsociacionesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AsociacionesRepository asociacionesRepository;

        public AsosiacionesBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            asociacionesRepository = new AsociacionesRepository(unitOfWork);
        }


        /// <summary>
        /// este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="asociacionesDM">recive la entidad asociasionesDM</param>
        /// <returns>regresa una cadena de inserción</returns>
        public string AddUpdateAsociaciones(AsociacionesDomainModel  asociacionesDM)
        {
            string resultado = string.Empty;
            if (asociacionesDM.IdAsociacion > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                catAsociaciones catAsociaciones = asociacionesRepository.SingleOrDefault(p=> p.idAsociacion== asociacionesDM.IdAsociacion);
                if (catAsociaciones != null)
                {
                    catAsociaciones.idAsociacion = asociacionesDM.IdAsociacion;
                    catAsociaciones.strDescripcion = asociacionesDM.StrDescripcion;
                    catAsociaciones.strObservacion = asociacionesDM.StrObservacion;
                    //actualizamos los datos en la base de datos.
                    asociacionesRepository.Update(catAsociaciones);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                catAsociaciones catAsociaciones = new catAsociaciones();
                catAsociaciones.idAsociacion = asociacionesDM.IdAsociacion;
                catAsociaciones.strDescripcion = asociacionesDM.StrDescripcion;
                catAsociaciones.strObservacion = asociacionesDM.StrObservacion;
                var record = asociacionesRepository.Insert(catAsociaciones);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }
       
        /// <summary>
        /// Este metodo se encarga de obtener todas las entidades del tipo asociaciones
        /// </summary>
        /// <returns>retorna una lista de asociaciones</returns>
        public List<AsociacionesDomainModel> GetAsociaciones()
        {
            List<AsociacionesDomainModel> asociaciones = null;
            asociaciones = asociacionesRepository.GetAll().Select(p => new AsociacionesDomainModel { IdAsociacion = p.idAsociacion, StrDescripcion = p.strDescripcion, StrObservacion = p.strObservacion }).ToList();
            AsociacionesDomainModel asociacionesDomainModel = new AsociacionesDomainModel();
            asociacionesDomainModel.IdAsociacion = 0;
            asociacionesDomainModel.StrDescripcion = "--Seleccionar--";
            asociaciones.Insert(0, asociacionesDomainModel);
            return asociaciones;
        }


    }
}
