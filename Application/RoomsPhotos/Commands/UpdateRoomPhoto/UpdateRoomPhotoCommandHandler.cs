using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.RoomsPhotos.Commands.UpdateRoomPhoto
{
    public class UpdateRoomPhotoCommandHandler : IRequestHandler<UpdateRoomPhotoCommand, RoomPhoto>
    {
        private readonly IDbContext _dbcontext;

        public UpdateRoomPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<RoomPhoto> Handle(UpdateRoomPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.roomPhotos.FirstOrDefaultAsync(photo => photo.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Photo), request.id);
            }

            entity.Result.roomID = request.roomID;
            entity.Result.photoID = request.photoID;

            var newPhoto = await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
