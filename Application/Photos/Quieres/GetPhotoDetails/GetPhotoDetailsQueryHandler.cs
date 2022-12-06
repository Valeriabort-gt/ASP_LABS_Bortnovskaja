using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Photos.Quieres.GetPhotoDetails
{
    public class GetPhotoDetailsQueryHandler : IRequestHandler<GetPhotoDetailsQuery, PhotoDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetPhotoDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<PhotoDetailsVm> Handle(GetPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.photos.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Photo), request.id);
            }

            return _mapper.Map<PhotoDetailsVm>(entity);
        }
    }
}
