﻿using AppDigitalCv.Business.Interface;
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
        private readonly PasatiempoRepository pasatiempoRepository;

        public DeportePersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            deportePersonalRepository = new DeportePersonalRepository(unitOfWork);
            pasatiempoRepository = new PasatiempoRepository(unitOfWork);
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
                    tblDeportePersonal.idDeportePersonal = deportePersonalDM.IdDeportePersonal;
                    tblDeportePersonal.idDeporte = deportePersonalDM.IdDeporte;
                    tblDeportePersonal.idPersonal = deportePersonalDM.IdPersonal;
                    tblDeportePersonal.dteFechaRegistro = DateTime.Parse(deportePersonalDM.FechaRegistro);
                    tblDeportePersonal.idFrecuencia = deportePersonalDM.IdFrecuencia;

                    tblPasatiempo tblPasatiempo = pasatiempoRepository.SingleOrDefault(p => p.idPersonal == deportePersonalDM.IdPersonal);
                    if (tblPasatiempo != null)
                    {
                        tblPasatiempo.idPasatiempo = deportePersonalDM.PasatiempoDM.IdPasatiempo;
                        tblPasatiempo.strDescripcion = deportePersonalDM.PasatiempoDM.StrDescripcion;
                        //actualizamos el pasatiempo
                        pasatiempoRepository.Update(tblPasatiempo);
                    }
                    
                    //actualizamos los datos en la base de datos.
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

                tblPasatiempo tblPasatiempo = new tblPasatiempo();
                tblPasatiempo.strDescripcion = deportePersonalDM.PasatiempoDM.StrDescripcion;
                
                //Insertamos el pasatiempo
                pasatiempoRepository.Insert(tblPasatiempo);

                ///insertamos en la entidad
                deportePersonalRepository.Insert(tblDeportePersonal);
                respuesta = true;
            }
            return respuesta;
        }




    }
}