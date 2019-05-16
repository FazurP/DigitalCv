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
          
            porcentaje.Insert(0,"0%");
            porcentaje.Insert(1,"5%");
            porcentaje.Insert(2,"10%");
            porcentaje.Insert(3,"15%");
            porcentaje.Insert(4,"20%");
            porcentaje.Insert(5,"25%");
            porcentaje.Insert(6,"30%");
            porcentaje.Insert(7,"35%");
            porcentaje.Insert(8,"40%");
            porcentaje.Insert(9,"45%");
            porcentaje.Insert(10,"50%");
            porcentaje.Insert(11,"55%");
            porcentaje.Insert(12,"60%");
            porcentaje.Insert(13,"65%");
            porcentaje.Insert(14,"70%"); 
            porcentaje.Insert(15,"75%");
            porcentaje.Insert(16,"80%");
            porcentaje.Insert(17,"85%");
            porcentaje.Insert(18,"90%");
            porcentaje.Insert(19,"95%");
            porcentaje.Insert(20,"100%");
         
            return porcentaje;
        }

    }
}