using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, Organization>
    {
        private readonly IDbContext _dbcontext;

        public CreateOrganizationCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Organization> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var record = new Organization
            {
                name = request.name,
                email = request.email
            };

            await _dbcontext.organizations.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
