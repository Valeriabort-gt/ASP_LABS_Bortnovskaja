using MediatR;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoDetails
{
    public class GetRoomPhotoDetailsQuery : IRequest<RoomPhotoDetailsVm>
    {
        public int id { get; set; }
    }
}
