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
    }
}
