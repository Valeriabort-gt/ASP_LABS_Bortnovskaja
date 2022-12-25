using Application.Common.Mappings;
using Domain;
using Application.Photos.Quieres.GetPhotoDetails;
using Application.Buildings.Quieres.GetBuildingDetails;
using AutoMapper;

namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoDetails
{
    public class BuildingPhotoDetailsVm : IMapWith<BuildingPhoto>
    {
        public int id { get; set; }
        public BuildingDetailsVm building { get; set; }
        public PhotoDetailsVm photo { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildingPhoto, BuildingPhotoDetailsVm>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.building, opt => opt.MapFrom(material => material.building))
                .ForMember(materialDto => materialDto.photo, opt => opt.MapFrom(material => material.photo));
        }
    }
}
