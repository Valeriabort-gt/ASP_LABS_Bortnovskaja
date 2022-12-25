using MediatR;

namespace Application.Photos.Quieres.GetPhotoDetails
{
    public class GetPhotoDetailsQuery : IRequest<PhotoDetailsVm>
    {
        public int id { get; set; }
    }
}
