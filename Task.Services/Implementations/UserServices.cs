using Microsoft.EntityFrameworkCore;
using Task.Data.Models.Identity;
using Task.Infrastructure.UnitOfWorks;
using Task.Services.Abstracts;

namespace Task.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<string> GetEmailByIdAsync(string id)
        {
            return await _unitOfWork.Repositry<ApplicationUser>()
                    .Get()
                .Where(u => u.Id == id)
                .Select(u => u.Email)
                .FirstOrDefaultAsync();

        }
    }
}
