using AutoMapper;
using MerchantMVC.Models;
using MerchantMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantMVC
{
    public class AutoMapperProfile:Profile
    {
       public AutoMapperProfile()
        {
            
            CreateMap<EditLocationViewModel, Location>()
                .ReverseMap();
            CreateMap<EditLocationViewModel, LocationActivate>()
                .ReverseMap();
            CreateMap<LoyaltyTranViewModel, LoyaltyTransactionTEc>()
                .ReverseMap();
            CreateMap<MerchantViewModel, Merchant>()
                .ReverseMap();
            CreateMap<FeedBackViewModel, FeedBack>()
                .ReverseMap();
            CreateMap<EntityDocumentMerchantViewModel, EntityDocumentMerchant>()
                .ReverseMap();
            CreateMap<CardViewModel, Card>()
                .ReverseMap();
            CreateMap<CallTrackingViewModel, CallTracking>()
                .ForMember(dest=>dest.DateTime, opt=>opt.MapFrom(src=>src.TrackingDateTime))
                .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>src.TrackingType))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ReverseMap();
        }
        
    }
}
