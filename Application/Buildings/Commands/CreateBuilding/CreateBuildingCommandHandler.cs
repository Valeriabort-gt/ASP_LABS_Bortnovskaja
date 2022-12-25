using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, Building>
    {
        private readonly IDbContext _dbcontext;

        public CreateBuildingCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Building> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = new Building
            {
                name = request.name,
                email = request.email,
                floorCount = request.floorCount,    
                description = request.description
            };

            await _dbcontext.buildings.AddAsync(building, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return building;
        }
    }
}
