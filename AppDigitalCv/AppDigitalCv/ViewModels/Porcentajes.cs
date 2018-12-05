using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class Porcentajes
    {

        public List<string> GetPorcentajes()
        {
            List<string> porcentaje = new List<string>();
            porcentaje.Add("0%");
            porcentaje.Add("5%");
            porcentaje.Add("10%");
            porcentaje.Add("15%");
            porcentaje.Add("20%");
            porcentaje.Add("25%");
            porcentaje.Add("30%");
            porcentaje.Add("35%");
            porcentaje.Add("40%");
            porcentaje.Add("45%");
            porcentaje.Add("50%");
            porcentaje.Add("55%");
            porcentaje.Add("60%");
            porcentaje.Add("65%");
            porcentaje.Add("70%"); 
            porcentaje.Add("75%");
            porcentaje.Add("80%");
            porcentaje.Add("85%");
            porcentaje.Add("90%");
            porcentaje.Add("95%");
            porcentaje.Add("100%");
            return porcentaje;
        }

    }
}