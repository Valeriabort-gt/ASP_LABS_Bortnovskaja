using AutoMapper;
using Application.Common.Mappings;
using Application.Invoices.Commands.UpdateInvoice;

namespace WebApplication.Models
{
    public class UpdateInvoiceDto : IMapWith<UpdateInvoiceCommand>
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string number { get; set; }
        public int organization { get; set; }
        public int room { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employee { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateInvoiceDto, UpdateInvoiceCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(invoiceCommand => invoiceCommand.createDate,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.createDate))
                .ForMember(invoiceCommand => invoiceCommand.number,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.number))
                .ForMember(invoiceCommand => invoiceCommand.organizationID,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.organization))
                .ForMember(invoiceCommand => invoiceCommand.roomID,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.room))
                .ForMember(invoiceCommand => invoiceCommand.puySum,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.puySum))
                .ForMember(invoiceCommand => invoiceCommand.payDate,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.payDate))
                .ForMember(invoiceCommand => invoiceCommand.employeeID,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.employee));
        }
    }
}
