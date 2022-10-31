using MediatR;

namespace Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int id { get; set; }
    }
}
