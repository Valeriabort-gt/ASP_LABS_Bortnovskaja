using AutoMapper;
using Application.Common.Mappings;
using Application.Organizations.Commands.CreateOrganization;
using Domain;

namespace WebApplication.Models
{
    public class CreateOrganizationDto : IMapWith<CreateOrganizationCommand>
    {
        public string name { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrganizationDto, CreateOrganizationCommand>()
                .ForMember(organizationCommand => organizationCommand.name,
                    opt => opt.MapFrom(organizationDto => organizationDto.name))
                .ForMember(organizationCommand => organizationCommand.email,
                    opt => opt.MapFrom(organizationDto => organizationDto.email));
        }
    }
}
