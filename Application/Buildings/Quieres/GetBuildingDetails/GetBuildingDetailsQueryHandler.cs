using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsQueryHandler : IRequestHandler<GetBuildingDetailsQuery, BuildingDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBuildingDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<BuildingDetailsVm> Handle(GetBuildingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.buildings.FirstOrDefaultAsync(building => building.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Building), request.id);
            }

            return _mapper.Map<BuildingDetailsVm>(entity);
        }
    }
}
