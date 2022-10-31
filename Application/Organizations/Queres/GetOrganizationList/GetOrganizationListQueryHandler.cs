using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Organizations.Queres.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, OrganizationListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetOrganizationListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<OrganizationListVm> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            var organizationsQuery = await _dbcontext.organizations.ProjectTo<OrganizationLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new OrganizationListVm { organizations = organizationsQuery };
        }
    }
}
