using Application.Common.Mappings;
using Domain;
using Application.Organizations.Queres.GetOrganizationDetails;
using Application.Rooms.Quieres.GetRoomDetails;
using Application.Employees.Quieres.GetEmployeeDetails;
using AutoMapper;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class InvoiceLookupDto : IMapWith<Invoice>
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string number { get; set; }
        //public OrganizationDetailsVm organization { get; set; }
        //public RoomDetailsVm room { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        //public EmployeeDetailsVm employee { get; set; }
        public EmployeeInvoiceLookupDto employee { get; set; }
        public OrganizationInvoiceLookupDto organization { get; set; }
        public RoomInvoiceLookupDto room { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceLookupDto>()
                .ForMember(invoiceDto => invoiceDto.id, opt => opt.MapFrom(invoice => invoice.id))
                .ForMember(invoiceDto => invoiceDto.createDate, opt => opt.MapFrom(invoice => invoice.createDate))
                .ForMember(invoiceDto => invoiceDto.number, opt => opt.MapFrom(invoice => invoice.number))
                .ForMember(invoiceDto => invoiceDto.organization, opt => opt.MapFrom(invoice => invoice.organization))
                .ForMember(invoiceDto => invoiceDto.room, opt => opt.MapFrom(invoice => invoice.room))
                .ForMember(invoiceDto => invoiceDto.puySum, opt => opt.MapFrom(invoice => invoice.puySum))
                .ForMember(invoiceDto => invoiceDto.payDate, opt => opt.MapFrom(invoice => invoice.payDate))
                .ForMember(invoiceDto => invoiceDto.employee, opt => opt.MapFrom(invoice => invoice.employee));
        }
    }
}
