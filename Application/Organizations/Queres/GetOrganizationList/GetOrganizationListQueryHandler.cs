using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Organizations.Queres.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, OrganizationListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetOrganizationListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<OrganizationListVm> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _dbcontext.organizations.Skip((request.page) * 15).Take(15).ProjectTo<OrganizationLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.organizations.Count() / 15.0).ToString()));
            return new OrganizationListVm
            {
                organizations = organizations,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/organization?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/organization?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount

            };
        }
    }
}
