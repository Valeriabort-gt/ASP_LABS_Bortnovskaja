using MediatR;
using Domain;

namespace Application.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string number { get; set; }
        public int organizationID { get; set; }
        public int roomID { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        public int employeeID { get; set; }
    }
}
