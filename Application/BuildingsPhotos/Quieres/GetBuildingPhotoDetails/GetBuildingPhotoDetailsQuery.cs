using MediatR;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoDetails
{
    public class GetBuildingPhotoDetailsQuery : IRequest<BuildingPhotoDetailsVm>
    {
        public int id { get; set; }
    }
}
