using MediatR;
using Domain;

namespace Application.BuildingsPhotos.Commands.DeleteBuildingPhoto
{
    public class DeleteBuildingPhotoCommand : IRequest
    {
        public int id { get; set; }
    }
}
