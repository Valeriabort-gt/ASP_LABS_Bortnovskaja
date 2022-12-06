using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoDetails
{
    public class GetBuildingPhotoDetailsQueryHandler : IRequestHandler<GetBuildingPhotoDetailsQuery, BuildingPhotoDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBuildingPhotoDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<BuildingPhotoDetailsVm> Handle(GetBuildingPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.buildingPhotos.FirstOrDefaultAsync(buildingPhoto => buildingPhoto.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(BuildingPhoto), request.id);
            }

            return _mapper.Map<BuildingPhotoDetailsVm>(entity);
        }
    }
}
