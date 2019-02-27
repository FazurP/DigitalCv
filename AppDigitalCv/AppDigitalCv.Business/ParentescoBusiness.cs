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
    }
}