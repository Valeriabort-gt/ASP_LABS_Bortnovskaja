using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Rents.Quieres.GetRentList
{
    public class RentLookupDto : IMapWith<Rent>
    {
        public int id { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }
        public Room room { get; set; }
        public Organization organization { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rent, RentLookupDto>()
                .ForMember(rentDto => rentDto.room, opt => opt.MapFrom(rent => rent.room))
                .ForMember(rentDto => rentDto.organization, opt => opt.MapFrom(rent => rent.organization))
                .ForMember(rentDto => rentDto.entryDate, opt => opt.MapFrom(rent => rent.entryDate))
                .ForMember(rentDto => rentDto.exitDate, opt => opt.MapFrom(rent => rent.exitDate));
        }
    }
}
