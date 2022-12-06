using AutoMapper;
using Application.Common.Mappings;
using Application.Users.Commands.UpdateUser;

namespace WebApplication.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(entity => entity.Id,
                    opt => opt.MapFrom(entityDto => entityDto.Id))
                .ForMember(entity => entity.Login,
                    opt => opt.MapFrom(entityDto => entityDto.Login))
                .ForMember(entity => entity.Password,
                    opt => opt.MapFrom(entityDto => entityDto.Password))
                .ForMember(entity => entity.RoleId,
                    opt => opt.MapFrom(entityDto => entityDto.RoleId));
        }
    }
}
