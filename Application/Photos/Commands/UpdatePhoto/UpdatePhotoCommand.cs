using MediatR;
using Domain;

namespace Application.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommand : IRequest<Photo>
    {
        public int id { get; set; }
        public string url { get; set; }
    }
}
