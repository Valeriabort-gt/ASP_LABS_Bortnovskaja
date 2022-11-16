using MediatR;
using Domain;

namespace Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public string numOfRoom { get; set; }
        public Building building { get; set; }
        public string description { get; set; }
        public int square { get; set; }
    }
}