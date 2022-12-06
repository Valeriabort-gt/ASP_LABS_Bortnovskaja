using MediatR;

namespace Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public int id { get; set; }
    }
}
