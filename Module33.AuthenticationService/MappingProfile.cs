using AutoMapper;
using Module33.AuthenticationService.Models;

namespace Module33.AuthenticationService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ConstructUsing(u => new UserViewModel(u));

        }   
    }
}
