using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Employees.Quieres.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, EmployeeListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetEmployeeListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.employees.Skip(request.page * 15).Take(15).ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.employees.Count() / 15.0).ToString()));
            return new EmployeeListVm
            {
                employees = records,
                totalElements = _dbcontext.employees.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
