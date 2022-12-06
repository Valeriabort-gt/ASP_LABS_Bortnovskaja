using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Domain;

namespace Application.Users.Quieres.GetUsersList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetUserListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.Users.Skip((request.page - 1) * 15).Take(15).Include(user => user.Role).ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.Users.Count() / 15.0).ToString()));
            return new UserListVm
            {
                users = records,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/users?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/users?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount
            };
        }
    }
}
