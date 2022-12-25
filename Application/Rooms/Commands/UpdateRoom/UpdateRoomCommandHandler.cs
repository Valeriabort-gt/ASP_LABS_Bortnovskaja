using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IDbContext _dbcontext;
        public UpdateRoomCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.rooms.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Room), request.id);
            }

            entity.Result.numOfRoom = request.numOfRoom;
            entity.Result.buildingID = request.buildingID;
            entity.Result.description = request.description;
            entity.Result.square = request.square;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
