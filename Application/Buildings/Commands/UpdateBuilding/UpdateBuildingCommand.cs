using MediatR;
using Domain;

namespace Application.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int floorCount { get; set; }
        public string description { get; set; }
    }
}
