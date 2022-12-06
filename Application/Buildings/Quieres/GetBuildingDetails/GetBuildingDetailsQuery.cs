using MediatR;

namespace Application.Buildings.Quieres.GetBuildingDetails
{
    public class GetBuildingDetailsQuery : IRequest<BuildingDetailsVm>
    {
        public int id { get; set; }
    }
}
