using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Users.Quieres.GetUsersList
{
    public class UserRoleLookupDto : IMapWith<UserRole>
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRole, UserRoleLookupDto>()
                .ForMember(entityDto => entityDto.Id, opt => opt.MapFrom(entity => entity.id))
                .ForMember(entityDto => entityDto.Role, opt => opt.MapFrom(entity => entity.Role));
        }
    }
}
