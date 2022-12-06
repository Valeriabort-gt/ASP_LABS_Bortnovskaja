using Domain;
using MediatR;

namespace Application.RoomsPhotos.Commands.DeleteRoomPhoto
{
    public class DeleteRoomPhotoCommand : IRequest
    {
        public int id { get; set; }
    }
}
