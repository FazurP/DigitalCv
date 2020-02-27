using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly bdGestionDocenteEntities1 _dbContext;

        public UnitOfWork()
        {
            _dbContext = new bdGestionDocenteEntities1();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
