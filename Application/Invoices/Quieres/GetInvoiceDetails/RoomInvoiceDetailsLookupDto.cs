using AutoMapper;
using Application.Common.Mappings;
using Domain;
using Application.Buildings.Quieres.GetBuildingDetails;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class RoomInvoiceDetailsLookupDto : IMapWith<Room>
    {
        public int id { get; set; }
        public string numOfRoom { get; set; }
        public BuildingDetailsVm building { get; set; }
        public string description { get; set; }
        public int square { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomInvoiceDetailsLookupDto>()
                .ForMember(Dto => Dto.id, opt => opt.MapFrom(room => room.id))
                .ForMember(Dto => Dto.numOfRoom, opt => opt.MapFrom(room => room.numOfRoom))
                .ForMember(Dto => Dto.description, opt => opt.MapFrom(room => room.description))
                .ForMember(Dto => Dto.square, opt => opt.MapFrom(room => room.square))
                .ForMember(Dto => Dto.building, opt => opt.MapFrom(room => room.building));
        }
    }
}
