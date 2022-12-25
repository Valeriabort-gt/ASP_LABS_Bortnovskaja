using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Rooms.Quieres.GetRoomList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, RoomListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetRoomListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RoomListVm> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _dbcontext.rooms.Skip((request.page - 1) * 15).Take(15).ProjectTo<RoomLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.rooms.Count() / 15.0).ToString()));
            return new RoomListVm
            {
                rooms = rooms,
                totalElements = _dbcontext.buildings.Count(),
                pagesCount = (int)pagesCount

            };
        }
    }
}
