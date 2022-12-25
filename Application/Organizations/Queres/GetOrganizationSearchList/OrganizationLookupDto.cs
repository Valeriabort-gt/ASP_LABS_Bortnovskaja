using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Organizations.Queres.GetOrganizationSearchList
{
    public class OrganizationLookupDto : IMapWith<Organization>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationLookupDto>()
                .ForMember(organizationDto => organizationDto.name, opt => opt.MapFrom(organization => organization.name))
                .ForMember(organizationDto => organizationDto.email, opt => opt.MapFrom(organization => organization.email))
                .ForMember(organizationDto => organizationDto.id, opt => opt.MapFrom(organization => organization.id));
        }
    }
}
