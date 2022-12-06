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
            var records = await _dbcontext.organizations.Where(item => item.name.Contains(request.searchText)).Skip((request.page - 1) * 15).Take(15).ProjectTo<OrganizationLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.organizations.Count() / 15.0).ToString()));
            return new OrganizationListVm
            {
                organizations = records,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/organization/Search?page={request.page + 1}&searchString={request.searchText}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/organization/Search?page={request.page - 1}&searchString={request.searchText}" : null,
                pagesCount = (int)pagesCount
            };
        }
    }
}
