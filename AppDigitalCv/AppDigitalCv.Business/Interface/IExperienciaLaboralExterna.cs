﻿using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IExperienciaLaboralExterna
    {
        bool AddUpdateExperiencia(ExperienciaLaboralExternaDomainModel experienciaLaboralExternaDM);

        List<ExperienciaLaboralExternaDomainModel> GetExperienciaLaboralByPersonal(int idPersonal);
        ExperienciaLaboralExternaDomainModel GetExperienciaLaboral(int idDocumento, int idPersonal);
    }
}
