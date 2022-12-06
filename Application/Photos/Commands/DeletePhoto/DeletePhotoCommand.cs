using MediatR;
using Domain;

namespace Application.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public int id { get; set; }
    }
}
