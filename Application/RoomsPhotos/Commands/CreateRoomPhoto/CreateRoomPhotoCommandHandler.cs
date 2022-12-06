using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.RoomsPhotos.Commands.CreateRoomPhoto
{
    public class CreateRoomPhotoCommandHandler : IRequestHandler<CreateRoomPhotoCommand, RoomPhoto>
    {
        private readonly IDbContext _dbcontext;

        public CreateRoomPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<RoomPhoto> Handle(CreateRoomPhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new RoomPhoto
            {
                photoID = request.photoID,
                roomID = request.roomID
            };

            var newPhoto = await _dbcontext.roomPhotos.AddAsync(photo, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return newPhoto.Entity;
        }
    }
}
