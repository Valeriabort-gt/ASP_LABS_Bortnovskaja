using MediatR;
using Domain;

namespace Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
