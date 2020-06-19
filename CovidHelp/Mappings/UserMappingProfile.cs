using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using CovidHelp.Resolvers;

namespace CovidHelp.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(dest => dest.UserAppliedOffer, opt => opt.Ignore())
                .ForMember(dest => dest.UserOffers, opt => opt.Ignore());

            CreateMap<UserModel, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => NameResolver.FullNameToFirstName(src.Name)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => NameResolver.FullNameToFirstName(src.Name)));

            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Pesel, opt => opt.MapFrom(src => src.Pesel))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                ;

            CreateMap<UserLoginModel, UserLogin>();

        }
    }
}
