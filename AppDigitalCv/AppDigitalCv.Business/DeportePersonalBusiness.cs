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
    public class DeportePersonalBusiness: IDeportePersonalBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DeportePersonalRepository deportePersonalRepository;

        public DeportePersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            deportePersonalRepository = new DeportePersonalRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas los deportes personales 
        /// </summary>
        /// <returns>regresa una lista de deportes personales del personal</returns>
        public List<DeportePersonalDomainModel> GetDeportesPersonalesById(int idPersonal)
        {
            List<DeportePersonalDomainModel> deportesPersonales = new List<DeportePersonalDomainModel>();
            Expression<Func<tblDeportePersonal, bool>> predicado = p => p.idPersonal.Equals(idPersonal);

            List<tblDeportePersonal> lista = deportePersonalRepository.GetAll(predicado).ToList<tblDeportePersonal>();
            if (lista != null)
            {
                foreach (var c in lista)
                {
                    FrecuenciaDomainModel FrecuenciaDM = new FrecuenciaDomainModel();
                    FrecuenciaDM.IdFrecuencia = c.catFrecuencia.idFrecuencia;
                    FrecuenciaDM.StrDescripcion = c.catFrecuencia.strDescripcion;

                    DeporteDomainModel DeporteDM = new DeporteDomainModel();
                    DeporteDM.IdDeporte = c.catDeporte.idDeporte;
                    DeporteDM.StrDescripcion = c.catDeporte.strDescripcion;

                    DeportePersonalDomainModel deportePersonalDM = new DeportePersonalDomainModel();
                    deportePersonalDM.IdDeportePersonal = c.idDeportePersonal;
                    deportePersonalDM.IdPersonal = c.idPersonal;
                    deportePersonalDM.IdDeporte = c.idDeporte;
                    deportePersonalDM.FechaRegistro = c.dteFechaRegistro.Value.ToShortDateString();
                    deportePersonalDM.IdFrecuencia = c.idFrecuencia;

                    deportePersonalDM.FrecuenciaDM = FrecuenciaDM;
                    deportePersonalDM.DeporteDM = DeporteDM;

                    deportesPersonales.Add(deportePersonalDM);




                }
            }
            
            return deportesPersonales;
        }


    }
}
