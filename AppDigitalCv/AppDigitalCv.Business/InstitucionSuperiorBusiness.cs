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
    public class InstitucionSuperiorBusiness: IInstitucionSuperiorBusiness
    {
        //Creacion de los objetos del repositorio
        private readonly IUnitOfWork unitOfWork;
        private readonly InstitucionSuperiorRepository institucionSuperiorRepository;

        public InstitucionSuperiorBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            institucionSuperiorRepository = new InstitucionSuperiorRepository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar todas las instituciones superiores del catalogo de la base de datos
        /// </summary>
        /// <returns>lista de instituciones superiores</returns>
        public List<InstitucionSuperiorDomainModel> GetInstitucionSuperior()
        {
            List<InstitucionSuperiorDomainModel> institucionSuperiorDomainModels = null;
            institucionSuperiorDomainModels = institucionSuperiorRepository.GetAll().Select(p => new InstitucionSuperiorDomainModel { IdInstitucionSuperior = p.idInstitucionSuperior, StrDescripcion = p.strDescripcion }).ToList();
            institucionSuperiorDomainModels.Insert(0,new InstitucionSuperiorDomainModel {IdInstitucionSuperior=0,StrDescripcion="Seleccionar" });
            return institucionSuperiorDomainModels;
        }

        /// <summary>
        /// Este metodo se ecarga de insertar o actualizar una entidad del tipo curso
        /// </summary>
        /// <param name="cursoDM">Entidad del tipo CursoDomainModel</param>
        /// <returns>una cadena de confirmación</returns>
        public string AddUpdateInstitucionSuperior(InstitucionSuperiorDomainModel institucionSuperiorDM)
        {
            string resultado = string.Empty;
            if (institucionSuperiorDM.IdInstitucionSuperior > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
              catInstitucionSuperior catInstitucion = institucionSuperiorRepository.SingleOrDefault(p => p.idInstitucionSuperior == institucionSuperiorDM.IdInstitucionSuperior);

                if (catInstitucion != null)
                {
                    catInstitucion.idInstitucionSuperior = institucionSuperiorDM.IdInstitucionSuperior;
                    catInstitucion.strDescripcion = institucionSuperiorDM.StrDescripcion;
                    catInstitucion.strObservacion = institucionSuperiorDM.StrObservacion;
                    institucionSuperiorRepository.Update(catInstitucion);
                    resultado = "Se Actualizo correctamente";
                }
            }
            else
            {
                catInstitucionSuperior catInstitucion = new catInstitucionSuperior();
                catInstitucion.strDescripcion = institucionSuperiorDM.StrDescripcion;
                catInstitucion.strObservacion = institucionSuperiorDM.StrObservacion;
                institucionSuperiorRepository.Insert(catInstitucion);
                resultado = "Se insertaron correctamente los valores";
            }

            return resultado;
        }


    }
}
