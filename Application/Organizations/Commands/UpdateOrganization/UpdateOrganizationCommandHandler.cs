using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;
using Application.Common.Exceptions;

namespace Application.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IDbContext _dbcontext;
        public UpdateOrganizationCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.organizations.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Organization), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.email = request.email;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

