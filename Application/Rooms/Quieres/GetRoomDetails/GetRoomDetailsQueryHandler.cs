using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;
using AutoMapper.QueryableExtensions;

namespace Application.Rooms.Quieres.GetRoomDetails
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetRoomDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RoomDetailsVm> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.rooms.ProjectTo<RoomDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(room => room.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Room), request.id);
            }

            return _mapper.Map<RoomDetailsVm>(entity);
        }
    }
}
