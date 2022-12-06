using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class OrganizationInvoiceDetailsLookupDto : IMapWith<Organization>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Organization, OrganizationInvoiceDetailsLookupDto>()
                .ForMember(Dto => Dto.id, opt => opt.MapFrom(organization => organization.id))
                .ForMember(Dto => Dto.name, opt => opt.MapFrom(organization => organization.name))
                .ForMember(Dto => Dto.email, opt => opt.MapFrom(organization => organization.email));
        }
    }
}
