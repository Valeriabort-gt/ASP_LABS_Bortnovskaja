using MediatR;
using Domain;

namespace Application.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest<Photo>
    {
        public string url { get; set; }
    }
}
