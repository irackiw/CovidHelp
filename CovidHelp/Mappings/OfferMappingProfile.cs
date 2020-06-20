using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CovidHelp.DataTransfer;
using CovidHelp.Models;
using CovidHelp.Models.Offer;
using CovidHelp.Resolvers;

namespace CovidHelp.Mappings
{
    public class OfferMappingProfile : Profile
    {
        public OfferMappingProfile()
        {
            CreateMap<CreateModel, Offer>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.ValidTo))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));

            CreateMap<ApplyOfferModel, UserAppliedOffer>()
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.OfferId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Offer, OfferModel>();

        }
    }
}
