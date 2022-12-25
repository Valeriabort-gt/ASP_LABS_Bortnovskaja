using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Rents.Quieres.GetRentList
{
    public class GetRentListQueryHandler : IRequestHandler<GetRentListQuery, RentListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetRentListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RentListVm> Handle(GetRentListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.rents.ProjectTo<RentLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new RentListVm { rents = records };
        }
    }
}
