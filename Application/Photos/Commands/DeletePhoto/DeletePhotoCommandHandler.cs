using MediatR;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeletePhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.photos.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Photo), request.id);
            }

            _dbcontext.photos.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
