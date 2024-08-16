using AutoMapper;
using Module33.AuthenticationService.DAL.Models;
using Module33.AuthenticationService.PLL;

namespace Module33.AuthenticationService.BLL
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
