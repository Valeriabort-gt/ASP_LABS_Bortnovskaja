using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Users.Quieres.GetUsersDetail
{
    public class UserDetailsVm : IMapWith<User>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRoleLookupDto Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(entityDto => entityDto.Id, opt => opt.MapFrom(entity => entity.id))
                .ForMember(entityDto => entityDto.Login, opt => opt.MapFrom(entity => entity.Login))
                .ForMember(entityDto => entityDto.Role, opt => opt.MapFrom(entity => entity.Role));
        }
    }
}
