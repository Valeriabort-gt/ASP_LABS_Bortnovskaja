using AutoMapper;
using Application.Common.Mappings;
using Domain;
using System.ComponentModel.DataAnnotations;
using Application.Buildings.Quieres.GetBuildingDetails;
using Application.Photos.Quieres.GetPhotoDetails;


namespace Application.BuildingsPhotos.Quieres.GetBuildingPhotoList
{
    public class BuildingPhotoLookupDto : IMapWith<BuildingPhoto>
    {
        public int id { get; set; }
        public BuildingDetailsVm building { get; set; }
        public PhotoDetailsVm photo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BuildingPhoto, BuildingPhotoLookupDto>()
                .ForMember(photoDto => photoDto.id, opt => opt.MapFrom(photo => photo.id))
                .ForMember(photoDto => photoDto.building, opt => opt.MapFrom(photo => photo.building))
                .ForMember(photoDto => photoDto.photo, opt => opt.MapFrom(photo => photo.photo));
        }
    }
}
