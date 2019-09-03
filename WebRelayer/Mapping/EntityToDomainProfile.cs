using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;
using WebRelayer.WebClientModels;

namespace WebRelayer.Mapping
{
    public class EntityToDomainProfile:Profile
    {
        public EntityToDomainProfile()
        {
            CreateMap<EmployeeArrival, EmployeeHistoryResponseModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Employee.Surname))
                .ForMember(dest => dest.ArrivedWhen, opt => opt.MapFrom(src => src.Arrival));
        }
    }
}
