using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Organizations.Queres.GetOrganizationDetails
{
    public class OrganizationDetailsVm : IMapWith<Organization>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationDetailsVm>()
                .ForMember(organizationVm => organizationVm.name, opt => opt.MapFrom(organization => organization.name))
                .ForMember(organizationVm => organizationVm.email, opt => opt.MapFrom(organization => organization.email))
                .ForMember(organizationVm => organizationVm.id, opt => opt.MapFrom(organization => organization.id));
        }
    }
}
