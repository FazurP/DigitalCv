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

                    deportePersonalDM.Frecuencia = FrecuenciaDM;
                    deportePersonalDM.Deporte = DeporteDM;
                    deportePersonalDM.strHorasPractica = c.strHorasPractica;

                    deportesPersonales.Add(deportePersonalDM);




                }
            }
            
            return deportesPersonales;
        }

        /// <summary>
        /// Este Metodo se encarga de agregar o actualizar un registro a la base de datos
        /// </summary>
        /// <param name="deportePersonalDM">recibe un objeto del tipo deportePersonalDM</param>
        /// <returns>regresa un valor booleano</returns>
        public bool AddUpdateHabitosPersonales(DeportePersonalDomainModel deportePersonalDM)
        {
            bool respuesta = false;
            tblDeportePersonal tblDeportePersonal = null;

            if (deportePersonalDM.IdDeportePersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblDeportePersonal = deportePersonalRepository.SingleOrDefault(p=> p.idDeportePersonal== deportePersonalDM.IdDeportePersonal);

                if (tblDeportePersonal != null)
                {
                    tblDeportePersonal.idDeporte = deportePersonalDM.IdDeporte;
                    tblDeportePersonal.idPersonal = deportePersonalDM.IdPersonal;
                    tblDeportePersonal.dteFechaRegistro = DateTime.Now;
                    tblDeportePersonal.idFrecuencia = deportePersonalDM.IdFrecuencia;
                    tblDeportePersonal.strHorasPractica = deportePersonalDM.strHorasPractica;
                    deportePersonalRepository.Update(tblDeportePersonal);
                    respuesta = true;

                }
            }
            else
            {

                tblDeportePersonal = new tblDeportePersonal();
                tblDeportePersonal.idDeporte = deportePersonalDM.IdDeporte;
                tblDeportePersonal.idPersonal = deportePersonalDM.IdPersonal;
                tblDeportePersonal.dteFechaRegistro = DateTime.Parse(deportePersonalDM.FechaRegistro);
                tblDeportePersonal.idFrecuencia = deportePersonalDM.IdFrecuencia;
                tblDeportePersonal.strHorasPractica = deportePersonalDM.strHorasPractica;
                deportePersonalRepository.Insert(tblDeportePersonal);
                respuesta = true;
            }
            return respuesta;
        }


        /// <summary>
        /// Este metodo se encarga de consultar todas los deportes personales 
        /// </summary>
        /// <returns>regresa una lista de deportes personales del personal</returns>
        public List<DeportePersonalDomainModel> GetDeportesPersonalesByIdDeportePersonal(int idDeportePersonal)
        {
            List<DeportePersonalDomainModel> deportesPersonales = new List<DeportePersonalDomainModel>();
            Expression<Func<tblDeportePersonal, bool>> predicado = p => p.idDeportePersonal.Equals(idDeportePersonal);

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

                    deportePersonalDM.Frecuencia = FrecuenciaDM;
                    deportePersonalDM.Deporte = DeporteDM;

                    deportesPersonales.Add(deportePersonalDM);
                }
            }

            return deportesPersonales;
        }


        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un  habito deportivo de la base de datos
        /// </summary>
        /// <param name="idDeportePersonal">recive un identificador del tipo deportepersonalDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteHabitoPersonal(int idDeportePersonal)
        {
            bool respuesta = false;
            Expression<Func<tblDeportePersonal, bool>> predicado = p => p.idDeportePersonal.Equals(idDeportePersonal);
            deportePersonalRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }


        /// <summary>
        /// Este metodo se encarga de consultar todas los deportes personales 
        /// </summary>
        /// <returns>regresa una lista de deportes personales del personal</returns>
        public DeportePersonalDomainModel GetDeportesPersonalByIdDeportePersonal(int idDeportePersonal)
        {
            DeportePersonalDomainModel deportePersonal = new DeportePersonalDomainModel();
            Expression<Func<tblDeportePersonal, bool>> predicado = p => p.idDeportePersonal.Equals(idDeportePersonal);
            
            tblDeportePersonal tblDeporte= deportePersonalRepository.SingleOrDefault(predicado);

            deportePersonal.IdDeporte = tblDeporte.idDeporte;
            deportePersonal.IdFrecuencia = tblDeporte.idFrecuencia;
            deportePersonal.IdDeportePersonal = tblDeporte.idDeportePersonal;
            deportePersonal.FechaRegistro = tblDeporte.dteFechaRegistro.Value.ToShortDateString();
            deportePersonal.strHorasPractica = tblDeporte.strHorasPractica;
            deportePersonal.Frecuencia = new FrecuenciaDomainModel { StrDescripcion = tblDeporte.catFrecuencia.strDescripcion };

            catDeporte catDeporte = new catDeporte();
            catDeporte.idDeporte = tblDeporte.idDeporte;
            catDeporte.strDescripcion = tblDeporte.catDeporte.strDescripcion;

            DeporteDomainModel deporteDM = new DeporteDomainModel();
            deporteDM.IdDeporte = catDeporte.idDeporte;
            deporteDM.StrDescripcion = catDeporte.strDescripcion;


            
            deportePersonal.Deporte = deporteDM;
           
            return deportePersonal;
        }


    }
}
