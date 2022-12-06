using AutoMapper;
using System;
using Application.Common.Mappings;
using Application.Employees.Commands.UpdateEmployee;

namespace WebApplication.Models
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.id,
                    opt => opt.MapFrom(employeeDto => employeeDto.id))
                .ForMember(employeeCommand => employeeCommand.name,
                    opt => opt.MapFrom(employeeDto => employeeDto.name))
                .ForMember(employeeCommand => employeeCommand.surname,
                    opt => opt.MapFrom(employeeDto => employeeDto.surname));
        }
    }
}
