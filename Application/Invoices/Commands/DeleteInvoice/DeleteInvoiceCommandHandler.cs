using MediatR;
using Application.Interfaces;
using Domain;
using Application.Common.Exceptions;

namespace Application.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeleteInvoiceCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.invoices.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Invoice), request.id);
            }

            _dbcontext.invoices.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
