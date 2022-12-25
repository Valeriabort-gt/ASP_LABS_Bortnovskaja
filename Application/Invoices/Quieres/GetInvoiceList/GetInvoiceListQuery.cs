using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class GetInvoiceListQuery : IRequest<InvoiceListVm>
    {
        public int page { get; set; }
       
    }
}
