using Domain;
using MediatR;

namespace Application.RoomsPhotos.Commands.UpdateRoomPhoto
{
    public class UpdateRoomPhotoCommand : IRequest<RoomPhoto>
    {
        public int id { get; set; }
        public int photoID { get; set; }
        public int roomID { get; set; }
    }
}
