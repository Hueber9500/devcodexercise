using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.Helpers;
using WebRelayer.WebClientModels;

namespace WebRelayer.Mapping
{
    public class ReponseToDomainModelProfile:Profile
    {
        public ReponseToDomainModelProfile()
        {
            CreateMap<AlaricMonitorResponseModel, SubscirptionDataModel>()
                .ForMember(dest => dest.ValidTo,
                opt => opt.MapFrom(src => src.ExpirationDate.StringISO8601ToDateTime()));
        }
    }
}
