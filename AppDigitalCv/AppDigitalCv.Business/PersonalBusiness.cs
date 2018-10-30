using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///implementamos la libreria de expression para el delegado
using System.Linq.Expressions;

namespace AppDigitalCv.Business
{
    public class PersonalBusiness: IPersonalBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly PersonalRepository personalRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma

        public PersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            personalRepository = new PersonalRepository(unitOfWork);
        }

        //este metodo sirve para agregar o editar un registro de el contexto seleccionado
        public string AddUpdatePersonal(PersonalDomainModel personalDM)
        {
            string resultado =string.Empty;
            if (personalDM.idPersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPersonal personal = personalRepository.SingleOrDefault(p => p.idPersonal == personalDM.idPersonal);
                if (personal != null)
                {
                    personal.strNombre = personalDM.Nombre;
                    personal.strApellidoPaterno = personalDM.ApellidoPaterno;
                    personal.strApellidoMaterno = personalDM.ApellidoMaterno;
                    personal.strCurp = personalDM.Curp;
                    personal.strRfc = personalDM.Rfc;
                    personal.strHomoclave = personalDM.Homoclave;
                    personal.strLogros = personalDM.strLogros;
                    personal.strUrlFoto = personalDM.strUrlFoto;
                    //actualizamos los datos en la base de datos.
                    personalRepository.Update(personal);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblPersonal personal = new tblPersonal();
                personal.strNombre = personalDM.Nombre;
                personal.strApellidoPaterno = personalDM.ApellidoPaterno;
                personal.strApellidoMaterno = personalDM.ApellidoMaterno;
                personal.strCurp = personalDM.Curp;
                personal.strRfc= personalDM.Rfc;
                personal.strUrlRfc = personalDM.strUrlRfc;
                personal.strUrlCurp = personalDM.strUrlCurp;
                personal.strLogros = personalDM.strLogros;
                personal.strUrlFoto = personalDM.strUrlFoto;
                
                /***********/ personal.archivoRfc = "archivo temporal"; /*********************/

                personal.strHomoclave = personalDM.Homoclave;
                var record = personalRepository.Insert(personal);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }

        public List<PersonalDomainModel> GetEmpleado() {
            List<PersonalDomainModel> lista = null; 
            lista =personalRepository.GetAll().Select(p=> new PersonalDomainModel {Nombre = p.strNombre, ApellidoPaterno = p.strApellidoPaterno
            , ApellidoMaterno= p.strApellidoMaterno,Curp=p.strCurp,Rfc=p.strRfc,idPersonal =p.idPersonal}).ToList();
            return lista;
        }

        /// <summary>
        /// este metodo se encarga de buscar a una persona por su id
        /// </summary>
        /// <param name="idPersonal">el identificador de la persona</param>
        /// <returns>regresa una persona en la capa de dominio</returns>
        public PersonalDomainModel GetPersonalById(int idPersonal)
        {
            Expression<Func<tblPersonal, bool>> predicado = p=> p.idPersonal.Equals(idPersonal);
            PersonalDomainModel personalDM = new PersonalDomainModel();
            tblPersonal TblPersonal= personalRepository.SingleOrDefault(predicado);
            personalDM.idPersonal = TblPersonal.idPersonal;
            personalDM.Nombre = TblPersonal.strNombre;
            personalDM.ApellidoPaterno = TblPersonal.strApellidoPaterno;
            personalDM.ApellidoMaterno = TblPersonal.strApellidoMaterno;
            personalDM.Curp = TblPersonal.strCurp;
            personalDM.Rfc = TblPersonal.strRfc;
            personalDM.Homoclave = TblPersonal.strHomoclave;
            personalDM.strLogros = TblPersonal.strLogros;
            return personalDM;
        }


    }
}
