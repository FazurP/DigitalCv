//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDigitalCv.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblHobbies
    {
        public int id { get; set; }
        public Nullable<int> idHobbie { get; set; }
        public Nullable<int> idFruencia { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public string strTiempoPractica { get; set; }
    
        public virtual catFrecuencia catFrecuencia { get; set; }
        public virtual CatHobbies CatHobbies { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
