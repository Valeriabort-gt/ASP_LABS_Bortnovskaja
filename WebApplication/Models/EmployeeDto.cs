using AutoMapper;
using System;
using Application.Common.Mappings;
using Domain;

namespace WebApplication.Models
{
    public class EmployeeDto : IMapWith<Employee>
    {
        public int id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeDto, Employee>()
                .ForMember(command => command.id,
                    opt => opt.MapFrom(Dto => Dto.id));
        }
    }
}
