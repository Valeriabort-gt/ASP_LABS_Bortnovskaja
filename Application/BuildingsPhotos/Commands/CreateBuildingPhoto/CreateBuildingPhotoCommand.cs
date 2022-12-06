using MediatR;
using Domain;

namespace Application.BuildingsPhotos.Commands.CreateBuildingPhoto
{
    public class CreateBuildingPhotoCommand : IRequest<BuildingPhoto>
    {
        public int buildingID { get; set; }
        public int photoID { get; set; }
        //public Building building { get; set; }
        //public Photo photo { get; set; }
    }
}
