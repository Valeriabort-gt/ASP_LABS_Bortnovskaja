using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Rooms.Quieres.GetRoomList
{
    public class RoomLookupDto : IMapWith<Room>
    {
        public int id { get; set; }
        public string numOfRoom { get; set; }
        public string description { get; set; }
        public int square { get; set; }
        public BuildingRoomLookupDto building { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomLookupDto>()
                .ForMember(roomDto => roomDto.numOfRoom, opt => opt.MapFrom(room => room.numOfRoom))
                .ForMember(roomDto => roomDto.building, opt => opt.MapFrom(room => room.building))
                .ForMember(roomDto => roomDto.description, opt => opt.MapFrom(room => room.description))
                .ForMember(roomDto => roomDto.square, opt => opt.MapFrom(room => room.square));
        }
    }
}
