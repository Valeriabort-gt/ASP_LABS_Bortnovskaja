using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class InvoiceLookupDto : IMapWith<Invoice>
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string number { get; set; }
        public int organizationID { get; set; }
        public int roomID { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employeeID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceLookupDto>()
                .ForMember(invoiceDto => invoiceDto.id, opt => opt.MapFrom(invoice => invoice.id))
                .ForMember(invoiceDto => invoiceDto.createDate, opt => opt.MapFrom(invoice => invoice.createDate))
                .ForMember(invoiceDto => invoiceDto.number, opt => opt.MapFrom(invoice => invoice.number))
                .ForMember(invoiceDto => invoiceDto.organizationID, opt => opt.MapFrom(invoice => invoice.organizationID))
                .ForMember(invoiceDto => invoiceDto.roomID, opt => opt.MapFrom(invoice => invoice.roomID))
                .ForMember(invoiceDto => invoiceDto.puySum, opt => opt.MapFrom(invoice => invoice.puySum))
                .ForMember(invoiceDto => invoiceDto.payDate, opt => opt.MapFrom(invoice => invoice.payDate))
                .ForMember(invoiceDto => invoiceDto.employeeID, opt => opt.MapFrom(invoice => invoice.employeeID));
        }
    }
}
