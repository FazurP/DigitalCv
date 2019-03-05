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
    public class ParentescoBusiness:IParentescoBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly ParentescoRepository parentescoRepository;
        
        public ParentescoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            parentescoRepository = new ParentescoRepository(unitOfWork);
            
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los parentescos posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de parentescos</returns>
        public List<ParentescoDomainModel> GetParentescos()
        {
            ///creamos la lista de parentesco, se encuentra vacia
            List<ParentescoDomainModel> parentesco = new List<ParentescoDomainModel>();
            //consultamos todos los parentescos y los almacenamos en la lista de parentescos
            parentesco = parentescoRepository.GetAll().Select(p => new ParentescoDomainModel { IdParentesco=p.idParentesco, StrDescripcion=p.strDescripcion  }).ToList();
            return parentesco;
        }
        /// <summary>
        /// Este metodo se encarga de consultar un aprentesco en particular
        /// </summary>
        /// <param name="idParentesco">recibe como parametro el identificador del parentesco</param>
        /// <returns>
        /// retorna  el parentesco del dato de contacto de emergencia de la persona
        /// </returns>
        public ParentescoDomainModel getParentescoById(int idParentesco)
        {
            ///creamos la lista de parentesco, se encuentra vacia
            ParentescoDomainModel parentesco = null;
            //consultamos  el parentesco de l persona
            Expression<Func<catParentesco, bool>> predicado = p => p.idParentesco.Equals(idParentesco);
            catParentesco  catparentesco = parentescoRepository.SingleOrDefault(predicado);
            parentesco.IdParentesco = catparentesco.idParentesco;
            parentesco.StrDescripcion = catparentesco.strDescripcion;
            parentesco.StrObservacion = catparentesco.strObservacion;
            return parentesco;
        }
    }
}
