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
    public class ManualOperacionBusiness : IManualOperacionBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ManualOperacionRepository manualOperacionRepository;
        public ManualOperacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            manualOperacionRepository = new ManualOperacionRepository(unitofWork);
        }

        public bool AddUpdateManualOperacion(ManualOperacionDomainModel manualOperacionDM)
        {
            bool respuesta = false;

            if (manualOperacionDM.id > 0)
            {
                Expression<Func<tblManualOperacion, bool>> predicate = p => p.id == manualOperacionDM.id;
                tblManualOperacion tblManual = manualOperacionRepository.GetAll(predicate).FirstOrDefault();

                if (tblManual != null)
                {
                    tblManual.strAutor = manualOperacionDM.strAutor;
                    tblManual.strDescripcion = manualOperacionDM.strDescripcion;
                    tblManual.strInstitucionBeneficiaria = manualOperacionDM.strInstitucionBeneficiaria;
                    tblManual.strNombre = manualOperacionDM.strNombre;

                    manualOperacionRepository.Update(tblManual);
                    respuesta = true;
                }
            }
            else
            {
                    tblManualOperacion tblManual = new tblManualOperacion();

                    tblManual.idPais = manualOperacionDM.idPais;
                    tblManual.idPersonal = manualOperacionDM.idPersonal;
                    tblManual.strDescripcion = manualOperacionDM.strDescripcion;
                    tblManual.strInstitucionBeneficiaria = manualOperacionDM.strInstitucionBeneficiaria;
                    tblManual.strNombre = manualOperacionDM.strNombre;
                    tblManual.strAutor = manualOperacionDM.strAutor;
                    tblManual.dteFechaPublicacion = manualOperacionDM.dteFechaPublicacion;

                    manualOperacionRepository.Insert(tblManual);
                    respuesta = true;
                
            }

            return respuesta;
        }

        public List<ManualOperacionDomainModel> GetManualesByPersonal(int _idPersonal)
        {
            List<ManualOperacionDomainModel> manualesOperacion= new List<ManualOperacionDomainModel>();

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblManualOperacion> tblManual = manualOperacionRepository.GetAll(predicate).ToList();

            foreach (tblManualOperacion tblManualOperacion in tblManual)
            {
                ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

                manualOperacionDM.id = tblManualOperacion.id;
                manualOperacionDM.idPais = tblManualOperacion.idPais.Value;
                manualOperacionDM.idPersonal = tblManualOperacion.idPersonal.Value;
                manualOperacionDM.strAutor = tblManualOperacion.strAutor;
                manualOperacionDM.strDescripcion = tblManualOperacion.strDescripcion;
                manualOperacionDM.strInstitucionBeneficiaria = tblManualOperacion.strInstitucionBeneficiaria;
                manualOperacionDM.strNombre = tblManualOperacion.strNombre;
                manualOperacionDM.dteFechaPublicacion = tblManualOperacion.dteFechaPublicacion;

                manualesOperacion.Add(manualOperacionDM);
            }

            return manualesOperacion;
        }

        public ManualOperacionDomainModel GetManualOperacion(int _idManual)
        {
            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.id == _idManual;

            tblManualOperacion tblManualOperacion = manualOperacionRepository.GetAll(predicate).FirstOrDefault();

            manualOperacionDM.id = tblManualOperacion.id;
            manualOperacionDM.idPais = tblManualOperacion.idPais.Value;
            manualOperacionDM.idPersonal = tblManualOperacion.idPersonal.Value;
            manualOperacionDM.strAutor = tblManualOperacion.strAutor;
            manualOperacionDM.strDescripcion = tblManualOperacion.strDescripcion;
            manualOperacionDM.strInstitucionBeneficiaria = tblManualOperacion.strInstitucionBeneficiaria;
            manualOperacionDM.strNombre = tblManualOperacion.strNombre;
            manualOperacionDM.dteFechaPublicacion = tblManualOperacion.dteFechaPublicacion;

            return manualOperacionDM;
        }

        public bool DeleteManualOperacion(int _idManual)
        {
            bool respuesta = false;

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.id == _idManual;

            manualOperacionRepository.Delete(predicate);
            respuesta = true;

            return respuesta;
        }
    }
}
