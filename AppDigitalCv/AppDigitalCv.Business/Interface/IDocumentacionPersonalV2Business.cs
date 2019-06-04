using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDocumentacionPersonalV2Business
    {
        bool AddDocumentacionPersonal(DocumentacionPersonalV2DomainModel documentacionPersonalDM);
        bool DeleteDocumentacionPersonal(int _idDocumento, int _idPersonal);
    }
}
