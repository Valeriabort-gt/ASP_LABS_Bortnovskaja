using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Rents.Quieres.GetRentDetails
{
    public class GetRentDetailsQueryHandler : IRequestHandler<GetRentDetailsQuery, RentDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetRentDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RentDetailsVm> Handle(GetRentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.rents.FirstOrDefaultAsync(rent => rent.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Rent), request.id);
            }

            return _mapper.Map<RentDetailsVm>(entity);
        }
    }
}
