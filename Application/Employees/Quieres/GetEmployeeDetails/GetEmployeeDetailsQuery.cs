using MediatR;

namespace Application.Employees.Quieres.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeDetailsVm>
    {
        public int id { get; set; }
    }
}
