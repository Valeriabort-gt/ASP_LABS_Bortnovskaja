using MediatR;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.BuildingsPhotos.Commands.DeleteBuildingPhoto
{
    public class DeleteBuildingPhotoCommandHandler : IRequestHandler<DeleteBuildingPhotoCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeleteBuildingPhotoCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteBuildingPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.buildingPhotos.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(BuildingPhoto), request.id);
            }

            _dbcontext.buildingPhotos.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
