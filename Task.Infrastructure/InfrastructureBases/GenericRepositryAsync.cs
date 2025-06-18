using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task.Infrastructure.DataAccess;
using Task.Infrastructure.InfrastructureBases;

namespace SchoolManagement.Infrastructure.InfrastructureBases
{
    public class GenericRepositryAsync<T> : IGenericRepositryAsync<T> where T : class
    {

        public DbSet<T> dbSet;
        private readonly ApplicationDbContext dbContext;
        public GenericRepositryAsync(ApplicationDbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }
        // CRUD
        public async Task<string> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            return "Success";
        }

        public async Task<string> Create(List<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return "Success";
        }

        public string Delete(T entity)
        {
            dbSet.Remove(entity);
            return "success";
        }

        public void Delete(List<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null
            , bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return query;
        }

        public async Task<T?> GetOne(
                                      Expression<Func<T, bool>>? filter = null,
                                      Func<IQueryable<T>, IQueryable<T>>? include = null,
                                      bool tracked = true)
        {
            return await Get(filter, include, tracked).FirstOrDefaultAsync();
        }


        public string Edit(T entity)
        {
            dbSet.Update(entity);
            return "success";
        }

        public IQueryable<T> GetQuarable(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
