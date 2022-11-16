using MediatR;

namespace Application.Rooms.Quieres.GetRoomDetails
{
    public class GetRoomDetailsQuery : IRequest<RoomDetailsVm>
    {
        public int id { get; set; }
    }
}
