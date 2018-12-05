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
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AccountRepository accountRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma

        public AccountBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            accountRepository = new AccountRepository(unitOfWork);
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
            Expression<Func<catUsuarios, bool>> predicado = p => p.strEmailInstitucional == AccountDomain.Email && p.strPassword == AccountDomain.Password;
            catUsuarios catUsuarios= accountRepository.SingleOrDefault(predicado);
            if (catUsuarios != null)
            {
                AccountDomainModel account = new AccountDomainModel();
                foreach (tblPersonal t in catUsuarios.tblPersonal)
                {
                    account.IdPersonal = t.idPersonal;
                }
                account.IdUsuario = catUsuarios.idUsuario;
                account.Email = catUsuarios.strEmailInstitucional;
                account.Password = catUsuarios.strPassword;
                account.Nombre = catUsuarios.strNombrUsuario; ///representara el nombre del usuario
                return account;
            }
            else
            {
                return null;
            }
        }

    }
}
