using Microsoft.EntityFrameworkCore.Storage;
using Task.Infrastructure.InfrastructureBases;

namespace Task.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepositryAsync<T> Repositry<T>() where T : class;
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public System.Threading.Tasks.Task CommitTransactionAsync();

        public System.Threading.Tasks.Task RollbackTransactionAsync();
        Task<int> CompleteAsync();
    }
}
