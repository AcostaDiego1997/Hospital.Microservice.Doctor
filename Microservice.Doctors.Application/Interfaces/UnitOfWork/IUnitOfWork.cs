using Microservice.Doctors.Application.Interfaces.Repository;

namespace Microservice.Doctors.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();

        IDoctor_Repository Doctor_Repository { get; }
    }
}
