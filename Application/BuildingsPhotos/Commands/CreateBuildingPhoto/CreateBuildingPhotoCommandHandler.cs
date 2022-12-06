using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.BuildingsPhotos.Commands.CreateBuildingPhoto
{
    public class CreateBuildingPhotoCommandHandler : IRequestHandler<CreateBuildingPhotoCommand, BuildingPhoto>
    {
        private readonly IDbContext _dbcontext;

        public CreateBuildingPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<BuildingPhoto> Handle(CreateBuildingPhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new BuildingPhoto
            {
                photoID = request.photoID,
                buildingID = request.buildingID
            };

            var newPhoto = await _dbcontext.buildingPhotos.AddAsync(photo, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return newPhoto.Entity;
        }
    }
}
