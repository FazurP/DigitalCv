using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Enum
{
    public class ListDocumentos
    {
        public List<string> fillDocuments()
        {
            List<string> documents = new List<string>();
            documents.Insert(0,"--Seleccionar--");
            documents.Insert(1,"Licencia de Manejo");
            documents.Insert(2,"Pasaporte");
            documents.Insert(3,"Visa de USA");
            documents.Insert(4,"Visa de Canada");
            documents.Insert(5,"Seguridad Social");
            documents.Insert(6,"Registro Prof, Estatal");
            documents.Insert(7,"Cartilla Militar");
            documents.Insert(8,"IFE");
            documents.Insert(9,"Comprobante de Domicilio");
            documents.Insert(10,"Solicitud de Empleo");

            return documents;
        }
    }
}
