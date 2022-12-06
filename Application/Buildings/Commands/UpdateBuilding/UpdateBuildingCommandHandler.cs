using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : IRequestHandler<UpdateBuildingCommand>
    {
        private readonly IDbContext _dbcontext;

        public UpdateBuildingCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;

        public async Task<Unit> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.buildings.FirstOrDefaultAsync(building => building.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Building), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.email = request.email;
            entity.Result.floorCount = request.floorCount;
            entity.Result.description = request.description;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
