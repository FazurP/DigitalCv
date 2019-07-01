using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class ProgresoProdepBusiness : IProgresoProdep
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ProgresoProdepRepository progresoProdepRepository;

        public ProgresoProdepBusiness(IUnitOfWork _unitOfWork) {

            unitofWork = _unitOfWork;
            progresoProdepRepository = new ProgresoProdepRepository(unitofWork);

        }
        public ProgresoProdepBusiness() {
        }
        public List<ProgresoProdepDomainModel> GetProgresoByPersonal(int _idPersonal) {
            List<ProgresoProdepDomainModel> progresos = new List<ProgresoProdepDomainModel>();

            Expression<Func<tblProgresoProdep, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblProgresoProdep> tblProgresos = progresoProdepRepository.GetAll(predicate).ToList();

            foreach (tblProgresoProdep item in tblProgresos)
            {
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

                progresoProdepDM.id = item.id;
                progresoProdepDM.idPersonal = item.idPersonal.Value;
                progresoProdepDM.idStatus = item.idStatus.Value;

                progresos.Add(progresoProdepDM);
            }

            return progresos;
        }
        public List<ProgresoProdepDomainModel> GetProgresoByPersonalBreak(int _idPersonal) {

            bdGestionDocenteEntities context = new bdGestionDocenteEntities();

            List<ProgresoProdepDomainModel> progresos = new List<ProgresoProdepDomainModel>();

            List<tblProgresoProdep> tblProgresos = context.tblProgresoProdep.Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (tblProgresoProdep item in tblProgresos)
            {
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

                progresoProdepDM.id = item.id;
                progresoProdepDM.idPersonal = item.idPersonal.Value;
                progresoProdepDM.idStatus = item.idStatus.Value;

                progresos.Add(progresoProdepDM);
            }

            return progresos;
        }
        public bool AddUpdateProgresoProdep(ProgresoProdepDomainModel progresoProdepDM) {

            bool respuesta = false;

            if (progresoProdepDM.id > 0)
            {

            }
            else {
                if (progresoProdepRepository.Exists(p => p.idPersonal == progresoProdepDM.idPersonal && p.idStatus == 2))
                {
                    respuesta = false;
                }
                else {
                
                tblProgresoProdep tblProgresoProdep = new tblProgresoProdep();

                tblProgresoProdep.id = progresoProdepDM.id;
                tblProgresoProdep.idPersonal = progresoProdepDM.idPersonal;
                tblProgresoProdep.idStatus = progresoProdepDM.idStatus;

                progresoProdepRepository.Insert(tblProgresoProdep);
                respuesta = true;
                }
            }

            return respuesta;
        }
        public bool DeleteProgresoProdep(int _idProgreso) {
            bool respuesta = false;

            Expression<Func<tblProgresoProdep, bool>> predicate = p => p.id == _idProgreso;

            progresoProdepRepository.Delete(predicate);
            respuesta = true;

            return respuesta;
             
        }
        public ProgresoProdepDomainModel GetProgresoPersonal(int _idPersonal, int _idStatus) {
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            Expression<Func<tblProgresoProdep, bool>> predicate = p => p.idPersonal == _idPersonal && p.idStatus == _idStatus;
            tblProgresoProdep tblProgresoProdep = progresoProdepRepository.GetAll(predicate).FirstOrDefault<tblProgresoProdep>();

            progresoProdepDM.id = tblProgresoProdep.id;
            progresoProdepDM.idPersonal = tblProgresoProdep.idPersonal.Value;
            progresoProdepDM.idStatus = tblProgresoProdep.idStatus.Value;

            return progresoProdepDM;
        }
    }
}
