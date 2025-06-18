using AutoMapper;
using Task.Core.Features.Authentication.Command.Models;
using Task.Data.Models.Identity;

namespace Task.Core.Mapping.User
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<RegisterUserCommand, ApplicationUser>()
                .ForMember(dest => dest.FullName,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        }
    }
}
