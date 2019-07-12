using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IProduccionesArtisticasBusiness
    {
        bool AddUpdateProduccionesArtisticas(ProduccionesArtisticasDomainModel produccionesArtisticasDM);
        List<ProduccionesArtisticasDomainModel> GetProduccionesArtisticasByPersonal(int _idPersonal);
        ProduccionesArtisticasDomainModel GetProduccion(int _idProduccion);
        bool DeleteProduccion(int _idProduccion);
    }
}
