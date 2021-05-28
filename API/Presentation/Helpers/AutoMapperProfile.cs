using AppCore.Entities;
using AppCore.ViewModel;
using AppCore.ViewModel.User;
using AutoMapper;

namespace Presentation
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserViewModel>()
                .ForMember(des=> des.Id, opt => opt.MapFrom(s=> s.Id.ToString()));
            CreateMap<UserViewModel, UserEntity>();

            CreateMap<CreateUserViewModel, UserEntity>();
            CreateMap<UserEntity, CreateUserViewModel>();

            CreateMap<Cnpjmin, CNPJEntity>();
            CreateMap<CNPJEntity, Cnpjmin>();



        }
    }
}
