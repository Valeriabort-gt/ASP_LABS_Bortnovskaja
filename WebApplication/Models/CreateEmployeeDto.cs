using AutoMapper;
using Application.Common.Mappings;
using Application.Employees.Commands.CreateEmployee;

namespace WebApplication.Models
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(employeeCommand => employeeCommand.name,
                    opt => opt.MapFrom(employeeDto => employeeDto.name))
                .ForMember(employeeCommand => employeeCommand.surname,
                    opt => opt.MapFrom(employeeDto => employeeDto.surname));
        }
    }
}
