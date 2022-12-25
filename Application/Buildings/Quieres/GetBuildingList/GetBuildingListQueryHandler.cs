using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Buildings.Quieres.GetBuildingList
{
    public class GetBuildingListQueryHandler : IRequestHandler<GetBuildingListQuery, BuildingListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetBuildingListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<BuildingListVm> Handle(GetBuildingListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.buildings.ProjectTo<BuildingLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new BuildingListVm { buildings = records };
        }
    }
}
