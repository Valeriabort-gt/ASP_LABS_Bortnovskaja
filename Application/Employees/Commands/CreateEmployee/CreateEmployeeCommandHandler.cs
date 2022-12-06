using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IDbContext _dbcontext;

        public CreateEmployeeCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                name = request.name,
                surname = request.surname
            };

            await _dbcontext.employees.AddAsync(employee, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
