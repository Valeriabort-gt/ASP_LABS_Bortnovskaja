using MediatR;
using Domain;

namespace Application.RoomsPhotos.Commands.CreateRoomPhoto
{
    public class CreateRoomPhotoCommand : IRequest<RoomPhoto>
    {
        public int roomID { get; set; }
        public int photoID { get; set; }
    }
}
