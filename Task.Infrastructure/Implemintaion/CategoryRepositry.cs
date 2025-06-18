using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.InfrastructureBases;
using Task.Data.Models.App;
using Task.Infrastructure.DataAccess;
using Task.Infrastructure.Repositry;

namespace Task.Infrastructure.Implemintaion
{
    public class CategoryRepositry : GenericRepositryAsync<Category>, ICategoryRepositry
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepositry(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<bool> IsCategoryNameUniqueAsync(string name)
        {
            return !await _dbContext.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

    }
}
