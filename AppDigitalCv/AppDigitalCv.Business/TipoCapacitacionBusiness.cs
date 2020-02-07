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
    public class TipoCapacitacionBusiness : ITipoCapacitacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TipoCapacitacionRepository tipoCapacitacionRepository;

        public TipoCapacitacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            tipoCapacitacionRepository = new TipoCapacitacionRepository(unitOfWork);
        }

        public List<TipoCapacitacionDomainModel> GetTiposCapacitacion()
        {
            List<TipoCapacitacionDomainModel> tipoCapacitacionDomainModels = new List<TipoCapacitacionDomainModel>();

            List<CatTiposCapacitacion> catTiposCapacitacions = new List<CatTiposCapacitacion>();

            catTiposCapacitacions = tipoCapacitacionRepository.GetAll().ToList();

            foreach (CatTiposCapacitacion item in catTiposCapacitacions)
            {
                TipoCapacitacionDomainModel tipoCapacitacionDomainModel = new TipoCapacitacionDomainModel();

                tipoCapacitacionDomainModel.id = item.id;
                tipoCapacitacionDomainModel.strValor = item.strValor;

                tipoCapacitacionDomainModels.Add(tipoCapacitacionDomainModel);

            }
            TipoCapacitacionDomainModel tipoCapacitacionDomainModel1 = new TipoCapacitacionDomainModel();

            tipoCapacitacionDomainModel1.id = 0;
            tipoCapacitacionDomainModel1.strValor = "Seleccionar";

            tipoCapacitacionDomainModels.Insert(0,tipoCapacitacionDomainModel1);

            return tipoCapacitacionDomainModels;
        }
    }
}
