using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Rents.Commands.CreateRent
{
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Rent>
    {
        private readonly IDbContext _dbcontext;

        public CreateRentCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Rent> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            var record = new Rent
            {
                roomID = request.room.id,
                organizationID = request.organization.id,
                entryDate = request.entryDate,
                exitDate = request.exitDate
            };

            await _dbcontext.rents.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
