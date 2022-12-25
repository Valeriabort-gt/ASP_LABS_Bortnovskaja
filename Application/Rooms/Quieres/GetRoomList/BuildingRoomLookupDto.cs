using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Rooms.Quieres.GetRoomList
{
    public class BuildingRoomLookupDto : IMapWith<Building>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int floorCount { get; set; }
        public string description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, BuildingRoomLookupDto>()
                .ForMember(Dto => Dto.id, opt => opt.MapFrom(building => building.id))
                .ForMember(Dto => Dto.name, opt => opt.MapFrom(building => building.name))
                .ForMember(Dto => Dto.email, opt => opt.MapFrom(building => building.email))
                .ForMember(Dto => Dto.floorCount, opt => opt.MapFrom(building => building.floorCount))
                .ForMember(Dto => Dto.description, opt => opt.MapFrom(building => building.description));
        }
    }
}
