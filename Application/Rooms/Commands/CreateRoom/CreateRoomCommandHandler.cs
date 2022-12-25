using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {
        private readonly IDbContext _dbcontext;

        public CreateRoomCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var record = new Room
            {
                numOfRoom = request.numOfRoom,
                buildingID = request.building.id,
                description = request.description,
                square = request.square
            };

            await _dbcontext.rooms.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
