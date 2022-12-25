using Application.Common.Mappings;
using Domain;
using Application.Organizations.Queres.GetOrganizationDetails;
using Application.Rooms.Quieres.GetRoomDetails;
using Application.Employees.Quieres.GetEmployeeDetails;
using AutoMapper;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class InvoiceDetailsVm : IMapWith<Invoice>
    {
        public int id { get; set; }
        public DateTime createDate{ get; set; }
        public string number { get; set; }
        public RoomInvoiceDetailsLookupDto room { get; set; }
        public OrganizationInvoiceDetailsLookupDto organization { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public EmployeeInvoiceDetailsLookupDto employee { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDetailsVm>()
                .ForMember(invoiceVm => invoiceVm.createDate, opt => opt.MapFrom(invoice => invoice.createDate))
                .ForMember(invoiceVm => invoiceVm.number, opt => opt.MapFrom(invoice => invoice.number))
                .ForMember(invoiceVm => invoiceVm.organization, opt => opt.MapFrom(invoice => invoice.organization))
                .ForMember(invoiceVm => invoiceVm.room, opt => opt.MapFrom(invoice => invoice.room))
                .ForMember(invoiceVm => invoiceVm.puySum, opt => opt.MapFrom(invoice => invoice.puySum))
                .ForMember(invoiceVm => invoiceVm.payDate, opt => opt.MapFrom(invoice => invoice.payDate))
                .ForMember(invoiceVm => invoiceVm.employee, opt => opt.MapFrom(invoice => invoice.employee))
                .ForMember(invoiceVm => invoiceVm.id, opt => opt.MapFrom(invoice => invoice.id));
        }
    }
}
