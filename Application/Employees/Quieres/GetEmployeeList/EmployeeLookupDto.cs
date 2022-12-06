using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Employees.Quieres.GetEmployeeList
{
    public class EmployeeLookupDto : IMapWith<Employee>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeLookupDto>()
                .ForMember(employeeDto => employeeDto.name, opt => opt.MapFrom(employee => employee.name))
                .ForMember(employeeDto => employeeDto.surname, opt => opt.MapFrom(employee => employee.surname))
                .ForMember(employeeDto => employeeDto.id, opt => opt.MapFrom(employee => employee.id));
        }
    }
}
