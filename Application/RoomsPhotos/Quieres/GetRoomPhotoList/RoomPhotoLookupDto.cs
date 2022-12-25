using AutoMapper;
using Application.Common.Mappings;
using Domain;
using System.ComponentModel.DataAnnotations;
using Application.Rooms.Quieres.GetRoomDetails;
using Application.Photos.Quieres.GetPhotoDetails;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoList
{
    public class RoomPhotoLookupDto : IMapWith<RoomPhoto>
    {
        public int id { get; set; }
        public RoomDetailsVm room { get; set; }
        public PhotoDetailsVm photo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoomPhoto, RoomPhotoLookupDto>()
                .ForMember(photoDto => photoDto.id, opt => opt.MapFrom(photo => photo.id))
                .ForMember(photoDto => photoDto.room, opt => opt.MapFrom(photo => photo.room))
                .ForMember(photoDto => photoDto.photo, opt => opt.MapFrom(photo => photo.photo));
        }
    }
}
