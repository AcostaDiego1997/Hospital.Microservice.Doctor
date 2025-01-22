using Microservice.Doctors.Application.Interfaces.Repository;
using Microservice.Doctors.Application.Interfaces.UnitOfWork;
using Microservice.Doctors.Infrastructure.Context;
using Microservice.Doctors.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Microservice.Doctors.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IDoctor_Repository _doctorRepository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext dataContext, IDoctor_Repository doctorRepository, IDbContextTransaction transaction)
        {
            _dataContext = dataContext;
            _doctorRepository = doctorRepository;
            _transaction = transaction;
        }

        public IDoctor_Repository Doctor_Repository => _doctorRepository ?? new Doctor_Repository(_dataContext);

        public void BeginTransaction()
        {
            if (_transaction != null)
                return;

            _transaction = _dataContext.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                _dataContext.SaveChanges();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await RollBackTransactionAsync();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            if (_transaction != null)
                _transaction.Dispose();
        }

        public async Task RollBackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public int SaveChanges()
        {
            int output = _dataContext.SaveChanges();
            return output;
        }
    }
}
