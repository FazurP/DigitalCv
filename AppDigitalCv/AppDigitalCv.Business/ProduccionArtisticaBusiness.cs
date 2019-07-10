using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class ProduccionArtisticaBusiness : IProduccionArtistica
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ProduccionArtisticaRepository produccionArtisticaRepository;

        public ProduccionArtisticaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            produccionArtisticaRepository = new ProduccionArtisticaRepository(unitofWork);
        }

        public List<ProduccionArtisticaDomainModel> GetProduccionesArtisticas()
        {
            List<ProduccionArtisticaDomainModel> produccionArtisticas = new List<ProduccionArtisticaDomainModel>();

            List<catProduccionArtistica> catProduccions = produccionArtisticaRepository.GetAll().ToList();

            foreach (catProduccionArtistica catProduccion in catProduccions)
            {
                ProduccionArtisticaDomainModel produccionArtisticaDM = new ProduccionArtisticaDomainModel();

                produccionArtisticaDM.id = catProduccion.id;
                produccionArtisticaDM.strDescripcion = catProduccion.strDescripcion;

                produccionArtisticas.Add(produccionArtisticaDM);
            }

            return produccionArtisticas;
        }
    }
}
