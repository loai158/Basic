using MediatR;
using Task.Data.Helpers;

namespace Task.Core.Features.Authentication.Command.Models
{
    public class RegisterUserCommand : IRequest<AuthModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string? PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
