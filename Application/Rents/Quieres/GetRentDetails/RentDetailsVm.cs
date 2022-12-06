using Application.Common.Mappings;
using Domain;
using Application.Organizations.Queres.GetOrganizationDetails;
using Application.Rooms.Quieres.GetRoomDetails;
using AutoMapper;

namespace Application.Rents.Quieres.GetRentDetails
{
    public class RentDetailsVm : IMapWith<Rent>
    {
        public int id { get; set; }
        public RoomDetailsVm room { get; set; }
        public OrganizationDetailsVm organization { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rent, RentDetailsVm>()
                .ForMember(rentVm => rentVm.room, opt => opt.MapFrom(rent => rent.room))
                .ForMember(rentVm => rentVm.organization, opt => opt.MapFrom(rent => rent.organization))
                .ForMember(rentVm => rentVm.entryDate, opt => opt.MapFrom(rent => rent.entryDate))
                .ForMember(rentVm => rentVm.exitDate, opt => opt.MapFrom(rent => rent.exitDate));
        }
    }
}
