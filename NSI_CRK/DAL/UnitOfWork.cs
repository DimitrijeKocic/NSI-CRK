using System;

namespace NSI_CRK.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CRKContext crkContext = new CRKContext();

        private IEmployeesRepository employeesRepository;
        private IPaymentsRepository paymentsRepository;
        private IAbsencesRepository absencesRepository;

        public IEmployeesRepository EmployeesRepository
        {
            get
            {
                if (this.employeesRepository == null)
                {
                    this.employeesRepository = new EmployeesRepository(crkContext);
                }
                return employeesRepository;
            }
        }
        public IPaymentsRepository PaymentsRepository
        {
            get
            {
                if (this.paymentsRepository == null)
                {
                    this.paymentsRepository = new PaymentsRepository(crkContext);
                }
                return paymentsRepository;
            }
        }
        public IAbsencesRepository AbsencesRepository
        {
            get
            {
                if (this.absencesRepository == null)
                {
                    this.absencesRepository = new AbsencesRepository(crkContext);
                }
                return absencesRepository;
            }
        }

        public void Save()
        {
            crkContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    crkContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}