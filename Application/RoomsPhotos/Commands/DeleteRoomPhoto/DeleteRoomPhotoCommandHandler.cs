using MediatR;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.RoomsPhotos.Commands.DeleteRoomPhoto
{
    public class DeleteRoomPhotoCommandHandler : IRequestHandler<DeleteRoomPhotoCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeleteRoomPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteRoomPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.roomPhotos.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(RoomPhoto), request.id);
            }

            _dbcontext.roomPhotos.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
