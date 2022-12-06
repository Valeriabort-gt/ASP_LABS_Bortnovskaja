using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class EmployeeInvoiceLookupDto : IMapWith<Employee>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeInvoiceLookupDto>()
                .ForMember(Dto => Dto.id, opt => opt.MapFrom(employee => employee.id))
                .ForMember(Dto => Dto.name, opt => opt.MapFrom(employee => employee.name))
                .ForMember(Dto => Dto.surname, opt => opt.MapFrom(employee => employee.surname));
        }
    }
}
