﻿using AppDigitalCv.Business.Enum;
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
    public class FamiliarBusiness : IFamiliarBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FamiliarRepository familiarRepository;
        private readonly PersonalRepository personalRepository;

        public FamiliarBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            familiarRepository = new FamiliarRepository(unitOfWork);
            personalRepository = new PersonalRepository(unitOfWork);
        }
        /// <summary>
        ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="familiarDM">recive una entidad familiar</param>
        /// <returns>regresa una cadena con la respuesta de la transacción</returns>
        public bool AddUpdateFamiliar(FamiliarDomainModel familiarDM)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            if (familiarDM.IdFamiliar > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                catFamiliar catFamiliar = familiarRepository.SingleOrDefault(p => p.idFamiliar == familiarDM.IdFamiliar);
                if (catFamiliar != null)
                {
                    catFamiliar.idFamiliar = familiarDM.IdFamiliar;
                    catFamiliar.idPersonal = familiarDM.IdPersonal;
                    catFamiliar.strDomicilio = familiarDM.StrDomicilio;
                    catFamiliar.strNombre = familiarDM.StrNombre;
                    catFamiliar.strApellidoPaterno = familiarDM.strApellidoPaterno;
                    catFamiliar.strApellidoMaterno = familiarDM.strApellidoMaterno;
                    catFamiliar.strOcupacion = familiarDM.StrOcupacion;
                    
                    //actualizamos la tabla catfamiliar
                    familiarRepository.Update(catFamiliar);
                    resultado = "Se Actualizo correctamente";
                    respuesta = true;
                }
            }
            else
            {
                catFamiliar catFamiliar = new catFamiliar();
                catFamiliar.idParentesco = familiarDM.IdParentesco;
                catFamiliar.strDomicilio = familiarDM.StrDomicilio;
                catFamiliar.strNombre = familiarDM.StrNombre;
                catFamiliar.strApellidoPaterno = familiarDM.strApellidoPaterno;
                catFamiliar.strApellidoMaterno = familiarDM.strApellidoMaterno;
                catFamiliar.strOcupacion = familiarDM.StrOcupacion;
                catFamiliar.idPersonal = familiarDM.IdPersonal;
                ///insertamos  la entidad catfamiliar
                familiarRepository.Insert(catFamiliar);
                resultado = "Se insertaron correctamente los valores";
                respuesta = true;
            }
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de obtener el famlair y su identificador a traves del nombre
        /// </summary>
        /// <param name="familiarDM">recibe una entidad del tipo FamiliarDomainModel</param>
        /// <returns>regresa una entidad del tipo FamiliarDomainModel</returns>
        public FamiliarDomainModel GetFamiliarByNombre(FamiliarDomainModel familiarDM)
        {
            Expression<Func<catFamiliar, bool>> predicado = p => p.strNombre.Equals(familiarDM.StrNombre);
            catFamiliar familiar = familiarRepository.SingleOrDefault(predicado);
            FamiliarDomainModel familiarDomanM = new FamiliarDomainModel();
            familiarDomanM.IdFamiliar = familiar.idFamiliar;
            familiarDomanM.StrNombre = familiar.strNombre;
            familiarDomanM.strApellidoPaterno = familiar.strApellidoPaterno;
            familiarDomanM.strApellidoMaterno = familiar.strApellidoPaterno;
            familiarDomanM.IdParentesco = familiar.idParentesco.Value;
            return familiarDomanM;
        }

        /// <summary>
        /// Este metodo se encarga de consultar los hijos o familaires de una persona
        /// </summary>
        /// <param name="idPersonal">recive el identificador de la persona</param>
        /// <returns>regresa una lista de los familiares en la entidad domain model</returns>
        public List<FamiliarDomainModel> GetFamiliaresById(int idPersonal)
        {
            List<FamiliarDomainModel> familiares = new List<FamiliarDomainModel>();
            Expression<Func<tblPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersonal);

            tblPersonal tblPersona = personalRepository.SingleOrDefault(predicado);
            foreach (catFamiliar catFamiliars in tblPersona.catFamiliar)
            {
                FamiliarDomainModel familiarDM = new FamiliarDomainModel();
                familiarDM.IdFamiliar = catFamiliars.idFamiliar;
                familiarDM.StrNombre = catFamiliars.strNombre;
                familiarDM.StrOcupacion = catFamiliars.strOcupacion;
                familiarDM.StrDomicilio = catFamiliars.strDomicilio;
                familiarDM.strApellidoPaterno = catFamiliars.strApellidoPaterno;
                familiarDM.strApellidoMaterno = catFamiliars.strApellidoMaterno;
                familiarDM.DteFechaNacimiento = catFamiliars.dteFechaNacimiento.ToString();
                familiarDM.IdParentesco = catFamiliars.idParentesco.Value;
                familiarDM.IdPersonal = catFamiliars.idPersonal.Value;
                familiarDM.Parentesco = new ParentescoDomainModel
                {
                    StrDescripcion = catFamiliars.catParentesco.strDescripcion
                };
                familiares.Add(familiarDM);
            }

            return familiares;

        }

        /// <summary>
        /// Este metodo se encarga de buscar un familiar por el identificador del familiar
        /// </summary>
        /// <param name="idFamiliar">identificador del familiar</param>
        /// <returns>regresa la entidad  del tipo FamiliarDomainModel</returns>
        public FamiliarDomainModel GetFamiliarByIdFamiliar(int idFamiliar)
        {
            Expression<Func<catFamiliar, bool>> predicado = p => p.idFamiliar.Equals(idFamiliar);
            catFamiliar familiar = familiarRepository.SingleOrDefault(predicado);
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            familiarDM.IdFamiliar = familiar.idFamiliar;
            familiarDM.IdParentesco = familiar.idParentesco.Value;
            familiarDM.IdPersonal = familiar.idPersonal.Value;
            familiarDM.strApellidoPaterno = familiar.strApellidoPaterno;
            familiarDM.strApellidoMaterno = familiar.strApellidoMaterno;
            familiarDM.StrDomicilio = familiar.strDomicilio;
            familiarDM.StrNombre = familiar.strNombre;
            familiarDM.StrOcupacion = familiar.strOcupacion;
            familiarDM.Parentesco = new ParentescoDomainModel
            {
                StrDescripcion = familiar.catParentesco.strDescripcion
            };
            return familiarDM;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un familiar d ela base de datos
        /// </summary>
        /// <param name="familiarDomainModel">recive una entidad del tipo familiarDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteFamiliar(FamiliarDomainModel familiarDomainModel)
        {
            bool respuesta = false;
            Expression<Func<catFamiliar, bool>> predicado = p => p.idFamiliar.Equals(familiarDomainModel.IdFamiliar);
            familiarRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un familiar d ela base de datos
        /// </summary>
        /// <param name="idFamiliar">recive un identificador del tipo familiarDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteFamiliar(int idFamiliar)
        {
            bool respuesta = false;
            Expression<Func<catFamiliar, bool>> predicado = p => p.idFamiliar.Equals(idFamiliar);
            familiarRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }


    }
}
