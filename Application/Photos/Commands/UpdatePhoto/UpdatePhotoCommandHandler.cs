using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Photo>
    {
        private readonly IDbContext _dbcontext;

        public UpdatePhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Photo> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.photos.FirstOrDefaultAsync(photo => photo.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Photo), request.id);
            }

            entity.Result.url = request.url;

            var newPhoto = await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
