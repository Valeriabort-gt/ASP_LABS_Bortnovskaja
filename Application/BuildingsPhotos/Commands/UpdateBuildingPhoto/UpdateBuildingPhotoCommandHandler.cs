using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.BuildingsPhotos.Commands.UpdateBuildingPhoto
{
    public class UpdateBuildingPhotoCommandHandler : IRequestHandler<UpdateBuildingPhotoCommand, BuildingPhoto>
    {
        private readonly IDbContext _dbcontext;

        public UpdateBuildingPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<BuildingPhoto> Handle(UpdateBuildingPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.buildingPhotos.FirstOrDefaultAsync(buildingPhoto => buildingPhoto.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(BuildingPhoto), request.id);
            }

            entity.Result.buildingID = request.buildingID;
            entity.Result.photoID = request.photoID;

            var newPhoto = await _dbcontext.SaveChangesAsync(cancellationToken);

            return entity.Result;
        }
    }
}
