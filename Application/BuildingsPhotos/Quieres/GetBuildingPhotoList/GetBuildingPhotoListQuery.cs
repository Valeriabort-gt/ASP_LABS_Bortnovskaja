using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoList
{
    public class GetBuildingPhotoListQuery : IRequest<BuildingPhotoListVm>
    {
        public int page { get; set; }
        public HostString url { get; set; }
    }
}
