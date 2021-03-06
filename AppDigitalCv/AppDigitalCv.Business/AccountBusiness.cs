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
//cargamos el archivo de recursos
using AppDigitalCv.Business.Recursos;

namespace AppDigitalCv.Business
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AccountRepository accountRepository;
        private readonly PersonalRepository personalRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma

        public AccountBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            accountRepository = new AccountRepository(unitOfWork);
            personalRepository = new PersonalRepository(unitOfWork);
        }

        
        /// <summary>
        /// Este metodo se encarga de validar el login de un usuario
        /// </summary>
        /// <param name="AccountDomain">recibe un accountDomain como objeto pasado por parametro</param>
        /// <returns>un valor booleano</returns>
        public bool Login(AccountDomainModel AccountDomain)
        {
            Expression<Func<catUsuarios, bool>> predicado = p => p.strEmailInstitucional == AccountDomain.Email && p.strPassword == AccountDomain.Password;
            return accountRepository.Exists(predicado);
        }

        public AccountDomainModel ValidarLogin(AccountDomainModel AccountDomain)
        {
            Expression<Func<catUsuarios, bool>> predicado = p => p.strNombrUsuario == AccountDomain.Email && p.strPassword == AccountDomain.Password;
            catUsuarios catUsuarios= accountRepository.SingleOrDefault(predicado);
            if (catUsuarios != null)
            {
                AccountDomainModel account = new AccountDomainModel();
                foreach (tblPersonal t in catUsuarios.tblPersonal)
                {
                    account.IdPersonal = t.idPersonal;
                    account.NombreCompleto = t.strNombre + " " + t.strApellidoPaterno + " "+t.strApellidoMaterno;
                    account.ImgUserUrl = t.strUrlFoto; //establecemos la  foto del usuario
                    account.Universidad = t.strUniversidad;
                    account.TipoPersonal = t.strTipoPersonal;
                    account.Sexo = t.strGenero;
                    _ = t.bitPermisoEncuesta == null ? t.bitPermisoEncuesta = false : t.bitPermisoEncuesta = t.bitPermisoEncuesta;
                    account.bitPermisoEncuesta = t.bitPermisoEncuesta.Value;
                }
                account.IdUsuario = catUsuarios.idUsuario;
                account.Email = catUsuarios.strEmailInstitucional;
                account.Password = catUsuarios.strPassword;
                account.Nombre = catUsuarios.strNombrUsuario; ///representara el nombre del usuario
                account.TipoUsuario = catUsuarios.strTipoUsuario;
               
                return account;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo se encarga de consultar el usuario y validar la cuenta a traves de un servicio externo
        /// </summary>
        /// <param name="AccountDomain">recibe una entidad del tipo accountdomain</param>
        /// <returns>una entidad accountDomainModel</returns>
        public AccountDomainModel ValidarLoginService(AccountDomainModel AccountDomain)
        {/*
            ServiceClient.wsusuariosSoapClient usuarioClient = new ServiceClient.wsusuariosSoapClient();
            
            AccountDomainModel account = new AccountDomainModel();
            #region  Credenciales Externas
            ServiceClient.Seguridad seguridad = new ServiceClient.Seguridad();
            seguridad.SegUsuario = Recursos.BaseConfiguration.SegUsuario;
            seguridad.SegPassword = Recursos.BaseConfiguration.SegPassword;
            #endregion

            #region Validacion del usuario Interno
            ServiceClient.Usuario usuario = new ServiceClient.Usuario();
            usuario.NomUsuario = AccountDomain.Nombre;
            usuario.Password = AccountDomain.Password;
            #endregion

            #region Consumo de Servicio
            var user= usuarioClient.ConsultaUsuarios(seguridad, usuario);
            if (user != null)
            {
                account.IdUsuario = int.Parse(user.IdUsuario);
                account.Nombre = user.Nombre;
                account.NombreCompleto = user.Nombre + " " + user.ApellidoPaterno + " " + user.ApellidoMaterno;
                account.Password = user.Clave;
                account.Email = user.Correo_Electronico;
            }
            return account;
            #endregion
            */
            return null;
        }

        public bool ExistUsuario(AccountDomainModel _accountDomainModel)
        {
            bool respuesta = false;
            catUsuarios catUsuarios = new catUsuarios();

            catUsuarios = accountRepository.GetAll().FirstOrDefault(p => p.strNombrUsuario == _accountDomainModel.Email);

            if (catUsuarios != null)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public bool AddUsuario(PersonalDomainModel personalDomainModel)
        {
            bool respuesta = false;
            catUsuarios catUsuarios = new catUsuarios();
            tblPersonal tblPersonal = new tblPersonal();

            if (!accountRepository.Exists(p => p.strEmailInstitucional == personalDomainModel.AccountDomainModel.Email))
            {
                tblPersonal.catUsuarios = new catUsuarios
                {
                    dteFechaRegistro = DateTime.Now,
                    idStatus = 1,//Por defecto es alta
                    strEmailInstitucional = personalDomainModel.AccountDomainModel.Email,
                    strNombrUsuario = personalDomainModel.AccountDomainModel.Nombre,
                    strPassword = personalDomainModel.AccountDomainModel.Password,
                    strTipoUsuario = personalDomainModel.AccountDomainModel.TipoUsuario
                };

                tblPersonal.strNombre = personalDomainModel.Nombre;
                tblPersonal.strApellidoPaterno = personalDomainModel.ApellidoPaterno;
                tblPersonal.strApellidoMaterno = personalDomainModel.ApellidoMaterno;
                tblPersonal.strUniversidad = personalDomainModel.strUniversidad;
                tblPersonal.strTipoPersonal = personalDomainModel.strTipoPersonal;

                personalRepository.Insert(tblPersonal);
                respuesta = true;
            }

            return respuesta;
        }

    }
}
