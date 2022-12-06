using MediatR;
using Domain;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
}
