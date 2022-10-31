using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Rents.Quieres.GetRentDetails
{
    public class RentDetailsVm : IMapWith<Rent>
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public int organizationID { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rent, RentDetailsVm>()
                .ForMember(rentVm => rentVm.roomID, opt => opt.MapFrom(rent => rent.roomID))
                .ForMember(rentVm => rentVm.organizationID, opt => opt.MapFrom(rent => rent.organizationID))
                .ForMember(rentVm => rentVm.entryDate, opt => opt.MapFrom(rent => rent.entryDate))
                .ForMember(rentVm => rentVm.exitDate, opt => opt.MapFrom(rent => rent.exitDate));
        }
    }
}
