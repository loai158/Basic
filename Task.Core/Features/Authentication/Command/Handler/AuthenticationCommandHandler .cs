using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Task.Core.Features.Authentication.Command.Models;
using Task.Data.Helpers;
using Task.Data.Models.Identity;
using Task.Services.Abstracts;

namespace Task.Core.Features.Authentication.Command.Handler
{
    public class AuthenticationCommandHandler : IRequestHandler<RegisterUserCommand, AuthModel>,
        IRequestHandler<LoginUserCommand, AuthModel>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AuthenticationCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._authService = authService;
        }
        public async Task<AuthModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // after validation we map 
            var identityUser = _mapper.Map<ApplicationUser>(request);
            //add to DB
            var result = await _userManager.CreateAsync(identityUser, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }
            await _userManager.AddToRoleAsync(identityUser, "User");
            //Get Token From authService
            var jwtSecurityToken = await _authService.CreateJwtToken(identityUser);
            //map to Auth Model
            return new AuthModel
            {
                Email = identityUser.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = identityUser.UserName
            };
        }

        public async Task<AuthModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Email or Password is incorrect!");

            }

            var jwtSecurityToken = await _authService.CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;
        }
    }
}
