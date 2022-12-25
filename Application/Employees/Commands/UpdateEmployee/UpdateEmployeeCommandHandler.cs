using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IDbContext _dbcontext;
        public UpdateEmployeeCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.employees.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Employee), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.surname = request.surname;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
