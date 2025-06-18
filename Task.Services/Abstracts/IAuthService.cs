using System.IdentityModel.Tokens.Jwt;
using Task.Data.Models.Identity;

namespace Task.Services.Abstracts
{
    public interface IAuthService
    {
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    }
}