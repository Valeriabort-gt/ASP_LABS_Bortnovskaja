using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Rooms.Quieres.GetRoomList
{
    public class GetRoomListQuery : IRequest<RoomListVm>
    {
        public int page { get; set; }
        
    }
}
