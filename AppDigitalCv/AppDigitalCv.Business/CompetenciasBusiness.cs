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
    public class CompetenciasBusiness : ICompetenciasBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly CompetenciasRepository competenciasRepository;

        public CompetenciasBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            competenciasRepository = new CompetenciasRepository(unitOfWork);
        }

        public List<CompetenciasDomainModel> GetCompetenciasHabilidad() {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Habilidad")).ToList();

            return competenciasDM;

        }
        public List<CompetenciasDomainModel> GetCompetenciasDestreza()
        {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Destreza")).ToList();

            return competenciasDM;

        }

        public List<CompetenciasDomainModel> GetCompetenciasValor()
        {

            List<CompetenciasDomainModel> competenciasDM = new List<CompetenciasDomainModel>();

            competenciasDM = competenciasRepository.GetAll().Select(p => new CompetenciasDomainModel
            {
                idCompetencia = p.idCompetencia,
                strObservacion = p.strObservacion,
                strDescripcion = p.strDescripcion,
                strTipo = p.strTipo

            }).Where(p => p.strTipo.Equals("Valor")).ToList();

            return competenciasDM;

        }

    }
}