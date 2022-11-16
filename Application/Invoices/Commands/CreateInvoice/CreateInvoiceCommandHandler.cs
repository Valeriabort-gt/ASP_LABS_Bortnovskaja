using MediatR;
using Domain;
using Application.Interfaces;


namespace Application.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
    {
        private readonly IDbContext _dbcontext;

        public CreateInvoiceCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var record = new Invoice
            {
                createDate = request.createDate,
                number = request.number,
                organizationID = request.organization.id,
                roomID = request.room.id,
                puySum = request.puySum,
                payDate = request.payDate,
                employeeID = request.employee.id
            };

            await _dbcontext.invoices.AddAsync(record, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return record;
        }
    }
}
