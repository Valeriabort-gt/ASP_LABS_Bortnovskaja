using Application.Common.Mappings;
using Domain;
using Application.Photos.Quieres.GetPhotoDetails;
using Application.Rooms.Quieres.GetRoomDetails;
using AutoMapper;

namespace Application.RoomsPhotos.Quieres.GetRoomPhotoDetails
{
    public class RoomPhotoDetailsVm : IMapWith<RoomPhoto>
    {
        public int id { get; set; }
        public RoomDetailsVm room { get; set; }
        public PhotoDetailsVm photo { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoomPhoto, RoomPhotoDetailsVm>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.room, opt => opt.MapFrom(material => material.room))
                .ForMember(materialDto => materialDto.photo, opt => opt.MapFrom(material => material.photo));
        }
    }
}
