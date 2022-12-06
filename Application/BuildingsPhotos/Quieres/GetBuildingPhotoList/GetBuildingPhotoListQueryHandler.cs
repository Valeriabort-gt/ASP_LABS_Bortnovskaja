using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoList
{
    public class GetBuildingPhotoListQueryHandler : IRequestHandler<GetBuildingPhotoListQuery, BuildingPhotoListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetBuildingPhotoListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<BuildingPhotoListVm> Handle(GetBuildingPhotoListQuery request, CancellationToken cancellationToken)
        {
            var photosQuery = await _dbcontext.buildingPhotos.ProjectTo<BuildingPhotoLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new BuildingPhotoListVm { buildingPhotos = photosQuery };
        }
    }
}
