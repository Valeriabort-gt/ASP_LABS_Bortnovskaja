using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Employees.Quieres.GetEmployeeList
{
    public class EmployeeListVm 
    {
        public IList<EmployeeLookupDto> employees { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
