using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Buildings.Quieres.GetBuildingDetails
{
    public class BuildingDetailsVm : IMapWith<Building>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int floorCount { get; set; }
        public string description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, BuildingDetailsVm>()
                .ForMember(buildingVm => buildingVm.name, opt => opt.MapFrom(building => building.name))
                .ForMember(buildingVm => buildingVm.email, opt => opt.MapFrom(building => building.email))
                .ForMember(buildingVm => buildingVm.floorCount, opt => opt.MapFrom(building => building.floorCount))
                .ForMember(buildingVm => buildingVm.description, opt => opt.MapFrom(building => building.description))
                .ForMember(buildingVm => buildingVm.id, opt => opt.MapFrom(building => building.id));
        }
    }
}
