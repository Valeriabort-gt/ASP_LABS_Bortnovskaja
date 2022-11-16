using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Employees.Quieres.GetEmployeeDetails
{
    public class EmployeeDetailsVm : IMapWith<Employee>
    {
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.name, opt => opt.MapFrom(employee => employee.name))
                .ForMember(employeeVm => employeeVm.surname, opt => opt.MapFrom(employee => employee.surname));
        }
    }
}
