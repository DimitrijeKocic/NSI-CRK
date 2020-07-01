using System;

namespace NSI_CRK.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository EmployeesRepository { get; }
        IPaymentsRepository PaymentsRepository { get; }
        IAbsencesRepository AbsencesRepository { get; }

        void Save();
    }
}
