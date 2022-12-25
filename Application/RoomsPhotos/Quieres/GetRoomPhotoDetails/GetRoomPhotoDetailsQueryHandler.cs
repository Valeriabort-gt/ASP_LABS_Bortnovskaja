using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoDetails
{
    public class GetRoomPhotoDetailsQueryHandler : IRequestHandler<GetRoomPhotoDetailsQuery, RoomPhotoDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetRoomPhotoDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<RoomPhotoDetailsVm> Handle(GetRoomPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.roomPhotos.FirstOrDefaultAsync(roomPhoto => roomPhoto.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(RoomPhoto), request.id);
            }

            return _mapper.Map<RoomPhotoDetailsVm>(entity);
        }
    }
}
