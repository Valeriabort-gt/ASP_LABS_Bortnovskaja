using MediatR;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class GetInvoiceDetailsQuery : IRequest<InvoiceDetailsVm>
    {
        public int id { get; set; }
    }
}
