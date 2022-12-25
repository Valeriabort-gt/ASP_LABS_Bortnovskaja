using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Employees.Quieres.GetEmployeeList
{
    public class GetEmployeeListQuery : IRequest<EmployeeListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
