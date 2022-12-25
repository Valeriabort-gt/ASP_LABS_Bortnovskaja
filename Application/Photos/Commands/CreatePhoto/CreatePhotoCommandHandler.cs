using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Photo>
    {
        private readonly IDbContext _dbcontext;

        public CreatePhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Photo> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new Photo
            {
                url = request.url
            };

            var newPhoto = await _dbcontext.photos.AddAsync(photo, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return newPhoto.Entity;
        }
    }
}
