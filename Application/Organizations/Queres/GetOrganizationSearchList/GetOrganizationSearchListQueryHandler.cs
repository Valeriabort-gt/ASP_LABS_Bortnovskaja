using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Organizations.Queres.GetOrganizationSearchList
{
    public class GetOrganizationSearchListQueryHandler : IRequestHandler<GetOrganizationSearchListQuery, OrganizationListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetOrganizationSearchListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<OrganizationListVm> Handle(GetOrganizationSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.organizations.Where(item => item.name.Contains(request.searchText)).ProjectTo<OrganizationLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new OrganizationListVm
            {
                organizations = records
            };
        }
    }
}
