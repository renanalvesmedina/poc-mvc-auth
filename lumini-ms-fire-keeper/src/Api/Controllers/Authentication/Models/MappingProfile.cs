using AutoMapper;
using Lumini.FireKeeper.Application.Requests.Authentication.CreateUser;
using Lumini.FireKeeper.Application.Requests.Authentication.UserLogin;

namespace Lumini.FireKeeper.Api.Controllers.Authentication.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserInput, CreateUserRequest>();

            CreateMap<UserLoginInput, UserLoginRequest>();
        }
    }
}
