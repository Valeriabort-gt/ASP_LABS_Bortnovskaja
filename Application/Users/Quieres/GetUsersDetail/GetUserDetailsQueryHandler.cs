using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Users.Quieres.GetUsersDetail
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetUserDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Users.Include(user => user.Role).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(User), request.id);
            }

            return new UserDetailsVm
            {
                Id = entity.id,
                Login = entity.Login,
                Password = entity.Password,
                Role = _mapper.Map<UserRoleLookupDto>(entity.Role)
            };
        }
    }
}
