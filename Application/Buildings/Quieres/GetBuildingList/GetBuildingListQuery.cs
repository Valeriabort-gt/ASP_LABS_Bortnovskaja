using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Buildings.Quieres.GetBuildingList
{
    public class GetBuildingListQuery : IRequest<BuildingListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
