using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDeportePersonalBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas los deportes personales 
        /// </summary>
        /// <returns>regresa una lista de deportes personales del personal</returns>
        List<DeportePersonalDomainModel> GetDeportesPersonalesById(int idPersonal);
        /// <summary>
        /// Este Metodo se encarga de agregar o actualizar un registro a la base de datos
        /// </summary>
        /// <param name="deportePersonalDM">recibe un objeto del tipo deportePersonalDM</param>
        /// <returns>regresa un valor booleano</returns>
        bool AddUpdateHabitosPersonales(DeportePersonalDomainModel deportePersonalDM);
        
        /// <summary>
        /// Este metodo se encarga de consultar todas los deportes personales 
        /// </summary>
        /// <returns>regresa una lista de deportes personales del personal</returns>
        List<DeportePersonalDomainModel> GetDeportesPersonalesByIdDeportePersonal(int idDeportePersonal);

    }
}
