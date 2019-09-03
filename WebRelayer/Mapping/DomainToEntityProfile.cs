using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.DomainModels;
using WebRelayer.Entities;

namespace WebRelayer.Mapping
{
    public class DomainToEntityProfile:Profile
    {
        public DomainToEntityProfile()
        {
            CreateMap<SubscirptionDataModel, SubscriptionData>();
            CreateMap<EmployeeArrivalInformationModel, EmployeeArrival>()
                .ForMember(dest => dest.Arrival, opt => opt.MapFrom(src => src.When));
        }
    }
}
