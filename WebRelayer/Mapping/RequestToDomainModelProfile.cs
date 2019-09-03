using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.WebClientModels;
using WebRelayer.Helpers;

namespace WebRelayer.Mapping
{
    public class RequestToDomainModelProfile:Profile
    {
        public RequestToDomainModelProfile()
        {
            CreateMap<AlaricMonitorRelayRequestModel, EmployeeArrivalInformationModel>()
                .ForMember(dest => dest.When, opt => opt.MapFrom(src => src.When.StringISO8601ToDateTime()));
        }
    }
}
