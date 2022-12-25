using MediatR;

namespace Application.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand : IRequest
    {
        public int id { get; set; } 
    }
}
