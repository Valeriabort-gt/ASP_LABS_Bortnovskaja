using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Photos.Quieres.GetPhotoDetails
{
    public class PhotoDetailsVm : IMapWith<Photo>
    {
        public string url { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Photo, PhotoDetailsVm>()
                .ForMember(photoVm => photoVm.url, opt => opt.MapFrom(photo => photo.url));
        }
    }
}
