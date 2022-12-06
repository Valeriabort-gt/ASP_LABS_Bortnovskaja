using AutoMapper;
using Application.Common.Mappings;
using Application.Invoices.Commands.CreateInvoice;

namespace WebApplication.Models
{
    public class CreateInvoiceDto : IMapWith<CreateInvoiceCommand>
    {
        public DateTime createDate { get; set; }
        public string number { get; set; }
        public int organization { get; set; }
        public int room { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employee { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateInvoiceDto, CreateInvoiceCommand>()
                .ForMember(invoiceCommand => invoiceCommand.createDate,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.createDate))
                .ForMember(invoiceCommand => invoiceCommand.number,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.number))
                .ForMember(invoiceCommand => invoiceCommand.organization,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.organization))
                .ForMember(invoiceCommand => invoiceCommand.room,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.room))
                .ForMember(invoiceCommand => invoiceCommand.puySum,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.puySum))
                .ForMember(invoiceCommand => invoiceCommand.payDate,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.payDate))
                .ForMember(invoiceCommand => invoiceCommand.employee,
                    opt => opt.MapFrom(invoiceDto => invoiceDto.employee));
        }
    }
}
