using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Photos.Quieres.GetPhotoList
{
    public class GetPhotoListQueryHandler : IRequestHandler<GetPhotoListQuery, PhotoListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetPhotoListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<PhotoListVm> Handle(GetPhotoListQuery request, CancellationToken cancellationToken)
        {
            var photosQuery = await _dbcontext.photos.ProjectTo<PhotoLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new PhotoListVm { photos = photosQuery };
        }
    }
}
