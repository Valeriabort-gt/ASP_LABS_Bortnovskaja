using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;
using AutoMapper.QueryableExtensions;

namespace Application.Organizations.Queres.GetOrganizationDetails
{
    public class GetOrganizationDetailsQueryHandler : IRequestHandler<GetOrganizationsDetailsQuery, OrganizationDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetOrganizationDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<OrganizationDetailsVm> Handle(GetOrganizationsDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.organizations.ProjectTo<OrganizationDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(organization => organization.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Organization), request.id);
            }

            return _mapper.Map<OrganizationDetailsVm>(entity);
        }
    }
}
