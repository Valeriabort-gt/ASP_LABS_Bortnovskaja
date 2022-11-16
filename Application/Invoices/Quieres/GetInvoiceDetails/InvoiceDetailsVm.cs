using Application.Common.Mappings;
using Domain;
using AutoMapper;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class InvoiceDetailsVm : IMapWith<Invoice>
    {
        public DateTime createDate{ get; set; }
        public string number { get; set; }
        public int organizationID { get; set; }
        public int roomID { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employeeID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceDetailsVm>()
                .ForMember(invoiceVm => invoiceVm.createDate, opt => opt.MapFrom(invoice => invoice.createDate))
                .ForMember(invoiceVm => invoiceVm.number, opt => opt.MapFrom(invoice => invoice.number))
                .ForMember(invoiceVm => invoiceVm.organizationID, opt => opt.MapFrom(invoice => invoice.organizationID))
                .ForMember(invoiceVm => invoiceVm.roomID, opt => opt.MapFrom(invoice => invoice.roomID))
                .ForMember(invoiceVm => invoiceVm.puySum, opt => opt.MapFrom(invoice => invoice.puySum))
                .ForMember(invoiceVm => invoiceVm.payDate, opt => opt.MapFrom(invoice => invoice.payDate))
                .ForMember(invoiceVm => invoiceVm.employeeID, opt => opt.MapFrom(invoice => invoice.employeeID));
        }
    }
}
