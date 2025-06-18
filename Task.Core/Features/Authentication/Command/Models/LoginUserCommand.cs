using MediatR;
using Task.Data.Helpers;

namespace Task.Core.Features.Authentication.Command.Models
{
    public class LoginUserCommand : IRequest<AuthModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
