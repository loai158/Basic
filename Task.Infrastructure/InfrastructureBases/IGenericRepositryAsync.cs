using System.Linq.Expressions;

namespace Task.Infrastructure.InfrastructureBases
{
    public interface IGenericRepositryAsync<T> where T : class
    {
        public Task<string> Create(T entity);
        public Task<string> Create(List<T> entities);

        public string Edit(T entity);

        public string Delete(T entity);

        public void Delete(List<T> entities);

        public void Commit();

        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null,
                                      Func<IQueryable<T>,
                                        IQueryable<T>>? include = null
                                         , bool tracked = true);
        public IQueryable<T> GetQuarable(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);

        public Task<T?> GetOne(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null
            , bool tracked = true);

    }

}
