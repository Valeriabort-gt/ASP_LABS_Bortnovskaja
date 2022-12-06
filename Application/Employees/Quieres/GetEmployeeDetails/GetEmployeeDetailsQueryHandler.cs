using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Employees.Quieres.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetEmployeeDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.employees.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Employee), request.id);
            }

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
