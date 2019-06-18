using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ParticipacionDocenteVM
    {
        public int Id { get; set; }
        public int IdCatDocumento { get; set; }
        public int IdPersonal { get; set; }
        [Required(ErrorMessage = "El Nombre del Evento es Obligatorio")]
        public string StrEvento { get; set; }
        [Required(ErrorMessage = "El tipo de Evento es Obligatorio")]
        public string StrTipoEvento { get; set; }
        public string StrParticipacion { get; set; }
        public string StrTipoParticipacion { get; set; }
        public bool BitPonencia { get; set; }
        public string StrNombrePonencia { get; set; }
        public string StrNombreInstitucionEmpresa { get; set; }
        public string StrLugar { get; set; }
        public string DteFecha { get; set; }

        public virtual DocumentosVM CatDocumentosVM{ get; set; }
        public virtual PersonalVM PersonalVM { get; set; }

        [Required(ErrorMessage = "El archivo es obligatorio")]
        public HttpPostedFileWrapper DcomentoPDF{ get; set; }
    }
}