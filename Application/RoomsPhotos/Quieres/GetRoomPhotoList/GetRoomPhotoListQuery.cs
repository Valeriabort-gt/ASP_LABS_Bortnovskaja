using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoList
{
    public class GetRoomPhotoListQuery : IRequest<RoomPhotoListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
