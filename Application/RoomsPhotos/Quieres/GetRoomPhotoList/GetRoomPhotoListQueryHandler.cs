using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoList
{
    public class GetRoomPhotoListQueryHandler : IRequestHandler<GetRoomPhotoListQuery, RoomPhotoListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetRoomPhotoListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RoomPhotoListVm> Handle(GetRoomPhotoListQuery request, CancellationToken cancellationToken)
        {
            var photosQuery = await _dbcontext.roomPhotos.ProjectTo<RoomPhotoLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new RoomPhotoListVm { roomPhotos = photosQuery };
        }
    }
}
