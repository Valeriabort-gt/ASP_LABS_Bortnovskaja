using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;


namespace Application.Rents.Commands.UpdateRent
{
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand>
    {
        private readonly IDbContext _dbcontext;
        public UpdateRentCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.rents.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Rent), request.id);
            }

            entity.Result.roomID = request.roomID;
            entity.Result.organizationID = request.organizationID;
            entity.Result.entryDate = request.entryDate;
            entity.Result.exitDate = request.exitDate;
            

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
