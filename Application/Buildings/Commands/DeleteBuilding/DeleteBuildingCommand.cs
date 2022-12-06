using MediatR;

namespace Application.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest
    {
        public int id { get; set; }
    }
}
