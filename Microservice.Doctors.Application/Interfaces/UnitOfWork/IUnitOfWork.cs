using Microservice.Doctors.Application.Interfaces.Repository;

namespace Microservice.Doctors.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();

        IDoctor_Repository Doctor_Repository { get; }
    }
}
