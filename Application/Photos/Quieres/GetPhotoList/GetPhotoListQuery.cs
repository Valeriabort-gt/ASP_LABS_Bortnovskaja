using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Photos.Quieres.GetPhotoList
{
    public class GetPhotoListQuery : IRequest<PhotoListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
