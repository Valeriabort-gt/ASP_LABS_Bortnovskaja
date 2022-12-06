using AutoMapper;
using Application.Common.Mappings;
using Domain;


namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class EmployeeInvoiceDetailsLookupDto : IMapWith<Employee>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeInvoiceDetailsLookupDto>()
                .ForMember(Dto => Dto.id, opt => opt.MapFrom(employee => employee.id))
                .ForMember(Dto => Dto.name, opt => opt.MapFrom(employee => employee.name))
                .ForMember(Dto => Dto.surname, opt => opt.MapFrom(employee => employee.surname));
        }
    }
}
