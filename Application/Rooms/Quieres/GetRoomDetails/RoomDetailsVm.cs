using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Rooms.Quieres.GetRoomDetails
{
    public class RoomDetailsVm : IMapWith<Room>
    {
        public int id { get; set; }
        public string numOfRoom { get; set; }
        public int buildingID { get; set; }
        public string description { get; set; }
        public int square { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomDetailsVm>()
                .ForMember(roomVm => roomVm.numOfRoom, opt => opt.MapFrom(room => room.numOfRoom))
                .ForMember(roomVm => roomVm.buildingID, opt => opt.MapFrom(room => room.buildingID))
                .ForMember(roomVm => roomVm.description, opt => opt.MapFrom(room => room.description))
                .ForMember(roomVm => roomVm.square, opt => opt.MapFrom(room => room.square));
        }
    }
}
