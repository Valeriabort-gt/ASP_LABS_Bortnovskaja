using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Rents.Quieres.GetRentList
{
    public class GetRentListQueryHandler : IRequestHandler<GetRentListQuery, RentListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;
        private readonly IMemoryCache _memoryCache;
        private readonly int CachingTime = 246;


        public GetRentListQueryHandler(IDbContext dbContext, IMapper mapper, IMemoryCache memory) => (_dbcontext, _mapper, _memoryCache) = (dbContext, mapper, memory);

        public async Task<RentListVm> Handle(GetRentListQuery request, CancellationToken cancellationToken)
        {
            if(!_memoryCache.TryGetValue(request.cacheKey, out RentListVm rents))
            {
                var rentsQuery = await _dbcontext.rents.ProjectTo<RentLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                rents = new RentListVm { rents = rentsQuery };
                if(rents != null)
                {
                    _memoryCache.Set(request.cacheKey, rents,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return rents;
        }
    }
}
