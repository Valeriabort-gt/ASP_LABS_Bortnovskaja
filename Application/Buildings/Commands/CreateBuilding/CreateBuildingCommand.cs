using MediatR;
using Domain;

namespace Application.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<Building>
    {
        public string name { get; set; }
        public string email { get; set; }
        public int floorCount { get; set; }
        public string description { get; set; }
    }
}
