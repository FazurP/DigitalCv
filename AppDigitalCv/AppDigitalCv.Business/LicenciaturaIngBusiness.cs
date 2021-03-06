﻿using AppDigitalCv.Business.Interface;
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
    public class LicenciaturaIngBusiness : ILicenciaturaIngBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LecenciaturaIngenieriaRepository lecenciaturaIngenieriaRepository;
        private readonly StatusLicenciaturaRepository statusLicenciaturaRepository;
        private readonly DocumentosRepository documentosRepository;

        public LicenciaturaIngBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            lecenciaturaIngenieriaRepository = new LecenciaturaIngenieriaRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
            statusLicenciaturaRepository = new StatusLicenciaturaRepository(unitOfWork);
        }

        public List<StatusLicenciaturaDomainModel> GetStatusLicenciaturas()
        {
            List<StatusLicenciaturaDomainModel> statusLicenciaturaDomainModels = new List<StatusLicenciaturaDomainModel>();
            List<CatStatusLicenciatura> status = new List<CatStatusLicenciatura>();

            status = statusLicenciaturaRepository.GetAll().ToList();

            foreach (CatStatusLicenciatura item in status)
            {
                StatusLicenciaturaDomainModel statusLicenciaturaDomainModel = new StatusLicenciaturaDomainModel();

                statusLicenciaturaDomainModel.id = item.id;
                statusLicenciaturaDomainModel.strDescripcion = item.strDescripcion;
                statusLicenciaturaDomainModel.strValor = item.strValor;

                statusLicenciaturaDomainModels.Add(statusLicenciaturaDomainModel);

            }

            StatusLicenciaturaDomainModel statusLicenciaturaDomainModel01 = new StatusLicenciaturaDomainModel();

            statusLicenciaturaDomainModel01.id = 0;
            statusLicenciaturaDomainModel01.strDescripcion = "Seleccionar";
            statusLicenciaturaDomainModel01.strValor = "Seleccionar";

            statusLicenciaturaDomainModels.Insert(0,statusLicenciaturaDomainModel01);

            return statusLicenciaturaDomainModels;
        }

        public int AddLicenciaturaIng(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {

            if (historialAcademicoDomainModel != null)
            {
                TblLicenciaturaIngenieria tblLicenciaturaIngenieria = new TblLicenciaturaIngenieria();

                tblLicenciaturaIngenieria.idIstitucionAcreditaLicenciatura = historialAcademicoDomainModel.InstitucionAcredita;
                tblLicenciaturaIngenieria.idPersonal = historialAcademicoDomainModel.idPersonal;
                tblLicenciaturaIngenieria.idStatusLicenciatura = historialAcademicoDomainModel.Status;
                tblLicenciaturaIngenieria.strNombre = historialAcademicoDomainModel.strNombre;

                lecenciaturaIngenieriaRepository.Insert(tblLicenciaturaIngenieria);

                return tblLicenciaturaIngenieria.id;

            }

            return 0;
        }

        public List<LicenciaturaIngenieriaDomainModel> GetLicenciaturasIngs(int idPersonal)
        {
            List<LicenciaturaIngenieriaDomainModel> licenciaturaIngenieriaDomainModels = new List<LicenciaturaIngenieriaDomainModel>();
            List<TblLicenciaturaIngenieria> tblLicenciaturaIngenierias = new List<TblLicenciaturaIngenieria>();

            tblLicenciaturaIngenierias = lecenciaturaIngenieriaRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (TblLicenciaturaIngenieria item in tblLicenciaturaIngenierias)
            {
                LicenciaturaIngenieriaDomainModel licenciaturaIngenieriaDomainModel = new LicenciaturaIngenieriaDomainModel();

                licenciaturaIngenieriaDomainModel.id = item.id;
                licenciaturaIngenieriaDomainModel.idInstitucionAcredita = item.idIstitucionAcreditaLicenciatura.Value;
                licenciaturaIngenieriaDomainModel.idPersonal = item.idPersonal.Value;
                licenciaturaIngenieriaDomainModel.idStatusLicenciatura = item.idStatusLicenciatura.Value;
                licenciaturaIngenieriaDomainModel.strNombre = item.strNombre;
                licenciaturaIngenieriaDomainModel.InstitucionAcreditaLicenciatura = new InstitucionAcreditaLicenciaturaDomainModel
                {
                    id = item.CatInstitucionAcreditaLicenciatura.id,
                    strDescripcion = item.CatInstitucionAcreditaLicenciatura.strDescripcion,
                    strValor =item.CatInstitucionAcreditaLicenciatura.strValor
                };
                licenciaturaIngenieriaDomainModel.StatusLicenciatura = new StatusLicenciaturaDomainModel
                {
                    id = item.CatStatusLicenciatura.id,
                    strDescripcion = item.CatStatusLicenciatura.strDescripcion,
                    strValor =item.CatStatusLicenciatura.strValor
                };
                licenciaturaIngenieriaDomainModels.Add(licenciaturaIngenieriaDomainModel);
            }

            return licenciaturaIngenieriaDomainModels;
        }

        public bool DeleteLicenciarturaIng(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel.LicenciaturaIngenieria.id > 0)
            {
                lecenciaturaIngenieriaRepository.Delete(p => p.id == historialAcademicoDomainModel.LicenciaturaIngenieria.id);
                respuesta = true;
            }

            return respuesta;
        }

        public LicenciaturaIngenieriaDomainModel GetLicenciaturaIng(int _id)
        {
            LicenciaturaIngenieriaDomainModel licenciaturaIngenieriaDomainModel = new LicenciaturaIngenieriaDomainModel();

            TblLicenciaturaIngenieria tblLicenciaturaIngenieria = lecenciaturaIngenieriaRepository.SingleOrDefault(p => p.id == _id);

            licenciaturaIngenieriaDomainModel.id = tblLicenciaturaIngenieria.id;
            licenciaturaIngenieriaDomainModel.idInstitucionAcredita = tblLicenciaturaIngenieria.idIstitucionAcreditaLicenciatura.Value;
            licenciaturaIngenieriaDomainModel.idPersonal = tblLicenciaturaIngenieria.idPersonal.Value;
            licenciaturaIngenieriaDomainModel.idStatusLicenciatura = tblLicenciaturaIngenieria.idStatusLicenciatura.Value;
            licenciaturaIngenieriaDomainModel.strNombre = tblLicenciaturaIngenieria.strNombre;
            licenciaturaIngenieriaDomainModel.InstitucionAcreditaLicenciatura = new InstitucionAcreditaLicenciaturaDomainModel
            {
                id = tblLicenciaturaIngenieria.CatInstitucionAcreditaLicenciatura.id,
                strDescripcion = tblLicenciaturaIngenieria.CatInstitucionAcreditaLicenciatura.strDescripcion,
                strValor = tblLicenciaturaIngenieria.CatInstitucionAcreditaLicenciatura.strValor
            };
            licenciaturaIngenieriaDomainModel.StatusLicenciatura = new StatusLicenciaturaDomainModel
            {
                id = tblLicenciaturaIngenieria.CatStatusLicenciatura.id,
                strDescripcion =tblLicenciaturaIngenieria.CatStatusLicenciatura.strDescripcion,
                strValor = tblLicenciaturaIngenieria.CatStatusLicenciatura.strValor
            };
            licenciaturaIngenieriaDomainModel.DocumentosProfesionales = new List<DocumentosProfesionalesDomainModel>();
            foreach (var item in tblLicenciaturaIngenieria.TblDocumentosProfesionales)
            {
                DocumentosProfesionalesDomainModel documentosProfesionalesDomainModel = new DocumentosProfesionalesDomainModel();

                documentosProfesionalesDomainModel.strNombre = item.strNombre;
                documentosProfesionalesDomainModel.id = item.id;

                licenciaturaIngenieriaDomainModel.DocumentosProfesionales.Add(documentosProfesionalesDomainModel);
            }


            return licenciaturaIngenieriaDomainModel;
        }
    }
}
