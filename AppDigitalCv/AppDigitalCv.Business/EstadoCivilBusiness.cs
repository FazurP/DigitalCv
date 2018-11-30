using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository.Infraestructure.Contract;
using AppDigitalCv.Repository;
using System.Linq.Expressions;

namespace AppDigitalCv.Business
{
    public class EstadoCivilBusiness : IEstadoCivilBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EstadoCivilRepository estadoCivilRepository;
        private readonly PersonalRepository personaRepository;

        public EstadoCivilBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            estadoCivilRepository = new EstadoCivilRepository(unitOfWork);
            personaRepository = new PersonalRepository(unitOfWork);
        }

        /// <summary>
        /// Metodo para llenar el dropdownlist de estado civil
        /// </summary>
        /// <returns> Regresa una lista de estados civiles </returns>
        public List<EstadoCivilDomainModel> GetEstadoCivil()
        {
            List<EstadoCivilDomainModel> estadoCivil = new List<EstadoCivilDomainModel>();
            estadoCivil = estadoCivilRepository.GetAll().Select(p => new EstadoCivilDomainModel { IdEstadoCivil = p.idEstadoCivil, StrDescripcion = p.strDescripcion }).ToList();
            EstadoCivilDomainModel inicial = new EstadoCivilDomainModel();
            inicial.IdEstadoCivil = 0;
            inicial.StrDescripcion = "-- Selecciona --";
            estadoCivil.Insert(0, inicial);
            return estadoCivil;
        }

        public string AddUpdateEstadocivil(PersonalDomainModel personaDM)
        {
            string resultado = string.Empty;
            if (personaDM.idEstadoCivil > 0)
            {
                tblPersonal persona = personaRepository.SingleOrDefault(P => P.idPersonal == personaDM.idPersonal);
                if (persona != null)
                {
                    persona.idEstadoCivil = personaDM.idEstadoCivil;
                    persona.strGenero = personaDM.strGenero;
                    personaRepository.Update(persona);
                    resultado = "Se Actualizo correctamente";
                }
            }
            else {
                tblPersonal personal = new tblPersonal();
                personal.idEstadoCivil = personaDM.idEstadoCivil;
                personal.strGenero = personaDM.strGenero;
                var record = personaRepository.Insert(personal);
                resultado = "Se insertaron correctamente";
            }
            return resultado;
        }

    }
}
