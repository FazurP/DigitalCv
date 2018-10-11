using AppDigitalCv.Business.Interface;
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
                    personal.strNombre = personalDM.strNombre;
                    personal.strApellidoPaterno = personalDM.strApellidoPaterno;
                    personal.strApellidoMaterno = personalDM.strApellidoMaterno;
                    personal.strCurp = personalDM.strCurp;
                    personal.strRfc = personalDM.strRfc;
                    //actualizamos los datos en la base de datos.
                    personalRepository.Update(personal);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblPersonal personal = new tblPersonal();
                personal.strNombre = personalDM.strNombre;
                personal.strApellidoPaterno = personalDM.strApellidoPaterno;
                personal.strApellidoMaterno = personalDM.strApellidoMaterno;
                personal.strCurp = personalDM.strCurp;
                personal.strRfc = personalDM.strRfc;
                var record = personalRepository.Insert(personal);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }

        public List<PersonalDomainModel> GetEmpleado() {
            List<PersonalDomainModel> lista = null; 
            lista =personalRepository.GetAll().Select(p=> new PersonalDomainModel {strNombre = p.strNombre}).ToList();
            return lista;
        }
    }
}
