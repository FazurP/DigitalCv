using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class CompetenciasTiVM
    {
        public int IdCompetenciaTIPersonal { get; set; }
        public int IdCompetenciaTI { get; set; }
        public int IdPersonal { get; set; }
        public string DteFechaRegistro { get; set; }

        public virtual CompetenciasTiVM CompetenciaVM { get; set; }
        public virtual PersonalVM PersonalVM { set; get; }
    }
}