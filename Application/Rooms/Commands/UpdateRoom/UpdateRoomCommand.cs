using MediatR;
using Domain;

namespace Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public int id { get; set; }
        public string numOfRoom { get; set; }
        public int buildingID { get; set; }
        public string description { get; set; }
        public int square { get; set; }
    }
}
