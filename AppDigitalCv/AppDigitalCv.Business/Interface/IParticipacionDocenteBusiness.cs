using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IParticipacionDocenteBusiness
    {
        /// <summary>
        /// Este metodo se encarga de agregar o actualizar los datos de participacion docebte de una persona
        /// </summary>
        /// <param name="participacionDocenteDM">recibe un objeto del tipo datos de  participaion docente</param>
        /// <returns>regresa un valor booleano</returns>
        bool AddUpdateParticipacionDocente(ParticipacionDocenteDomainModel participacionDocenteDM);
    }
}
