using MediatR;
using Domain;

namespace Application.BuildingsPhotos.Commands.UpdateBuildingPhoto
{
    public class UpdateBuildingPhotoCommand : IRequest<BuildingPhoto>
    {
        public int id { get; set; }
        public int photoID { get; set; }
        public int buildingID { get; set; }
    }
}
