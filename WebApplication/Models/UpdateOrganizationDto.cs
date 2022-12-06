using AutoMapper;
using Application.Common.Mappings;
using Application.Organizations.Commands.UpdateOrganization;

namespace WebApplication.Models
{
    public class UpdateOrganizationDto : IMapWith<UpdateOrganizationCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrganizationDto, UpdateOrganizationCommand>()
                .ForMember(organizationCommand => organizationCommand.id,
                    opt => opt.MapFrom(organizationDto => organizationDto.id))
                .ForMember(organizationCommand => organizationCommand.name,
                    opt => opt.MapFrom(organizationDto => organizationDto.name))
                .ForMember(organizationCommand => organizationCommand.email,
                    opt => opt.MapFrom(organizationDto => organizationDto.email));
        }
    }
}
