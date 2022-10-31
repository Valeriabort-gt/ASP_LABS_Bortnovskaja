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
            var roomsQuery = await _dbcontext.rooms.ProjectTo<RoomLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new RoomListVm { rooms = roomsQuery };
        }
    }
}
