using AutoMapper;
using System;
using Application.Common.Mappings;
using Application.Users.Commands.CreateUser;

namespace WebApplication.Models
{
    public class SignUpUserDto : IMapWith<CreateUserCommand>
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SignUpUserDto, CreateUserCommand>()
                .ForMember(customerCommand => customerCommand.Login,
                    opt => opt.MapFrom(customerDto => customerDto.Login))
                .ForMember(customerCommand => customerCommand.Password,
                    opt => opt.MapFrom(customerDto => customerDto.Password));
        }
    }
}
